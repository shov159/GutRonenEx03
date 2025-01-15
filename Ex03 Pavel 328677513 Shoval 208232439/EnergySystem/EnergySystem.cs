using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// מחלקה אבסטרקטית המייצגת מערכת אנרגיה (דלק / חשמל).
    /// </summary>
    public abstract class EnergySystem
    {
        protected float m_RemainingEnergy = 0;
        protected float m_MaxEnergy = 0;

    
        protected EnergySystem(float i_MaxEnergy, float i_InitialEnergy)
        {
            if (i_MaxEnergy <= 0)
            {
                throw new ArgumentException("MaxEnergy must be greater than zero.");
            }

            if (i_InitialEnergy < 0 || i_InitialEnergy > i_MaxEnergy)
            {
                throw new ValueOutOfRangeException(
                    0f,
                    i_MaxEnergy,
                    $"Initial energy {i_InitialEnergy} is out of the valid range (0 - {i_MaxEnergy}).");
            }

            m_MaxEnergy = i_MaxEnergy;
            m_RemainingEnergy = i_InitialEnergy;
        }

        /// <summary>
        /// כמות האנרגיה הנוכחית (ליטרים / שעות).
        /// </summary>
        public float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
            protected set
            {
                // אפשר להוסיף בדיקות נוספות כאן אם רוצים
                if (value < 0 || value > m_MaxEnergy)
                {
                    throw new ValueOutOfRangeException(
                        0f,
                        m_MaxEnergy,
                        $"Remaining energy {value} is out of the valid range (0 - {m_MaxEnergy}).");
                }

                m_RemainingEnergy = value;
            }
        }

        /// <summary>
        /// קיבולת מקסימלית של הדלק/סוללה.
        /// </summary>
        public float MaxEnergy
        {
            get { return m_MaxEnergy; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MaxEnergy must be greater than zero.");
                }

                m_MaxEnergy = value;
            }
        }

        /// <summary>
        /// אחוז האנרגיה הנוכחי (0-100).
        /// </summary>
        public float EnergyPercentage
        {
            get
            {
                return (RemainingEnergy / MaxEnergy) * 100f;
            }
        }

        /// <summary>
        /// מתודה אבסטרקטית להוספת אנרגיה (תדלוק/טעינה).
        /// </summary>
        /// <param name="i_AmountToAdd">כמות האנרגיה להוסיף (בליטרים או שעות).</param>
        public abstract void AddEnergy(float i_AmountToAdd);

        /// <summary>
        /// בדיקות משותפות לפני הוספת אנרגיה:
        /// 1. כמות להוספה לא שלילית.
        /// 2. מניעה מלחרוג מעל המקסימום.
        /// </summary>
        /// <param name="i_AmountToAdd"></param>
        /// <returns>ערך אנרגיה חדש (RemainingEnergy + i_AmountToAdd), אם הכל תקין.</returns>
        /// <exception cref="ArgumentException">אם הכמות להוספה שלילית</exception>
        /// <exception cref="ValueOutOfRangeException">אם התוספת חורגת מהמקסימום</exception>
        protected float ValidateAndCalcNewEnergy(float i_AmountToAdd)
        {
            if (i_AmountToAdd < 0)
            {
                throw new ArgumentException(
                    "Cannot add negative amount of energy.",
                    nameof(i_AmountToAdd));
            }

            float newEnergyLevel = m_RemainingEnergy + i_AmountToAdd;
            if (newEnergyLevel > m_MaxEnergy)
            {
                float maxPossibleToAdd = m_MaxEnergy - m_RemainingEnergy;
                throw new ValueOutOfRangeException(
                    0f,
                    maxPossibleToAdd,
                    $"Amount to add ({i_AmountToAdd}) exceeds the maximum capacity. " +
                    $"You can only add up to {maxPossibleToAdd} units.");
            }

            return newEnergyLevel;
        }

        public override string ToString()
        {
            return string.Format(
                "Energy System: {0}, Remaining={1:0.00}, Max={2:0.00}, Percentage={3:0.0}%",
                this.GetType().Name,
                RemainingEnergy,
                MaxEnergy,
                EnergyPercentage);
        }
    }
}



