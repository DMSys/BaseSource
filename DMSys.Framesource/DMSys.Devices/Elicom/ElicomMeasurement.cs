using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Devices.Elicom
{
    public delegate void ElicomMeasurementEventHandler(object sender, ElicomMeasurement e);

    public class ElicomMeasurement
    {
        private bool _IsTare = false;
        /// <summary>
        /// тегло/тара
        /// </summary>
        public bool IsTare
        {
            get
            { return _IsTare; }
        }

        private bool _IsNegativeWeight = false;
        /// <summary>
        /// отрицателно тегло
        /// </summary>
        public bool IsNegativeWeight
        {
            get
            { return _IsNegativeWeight; }
        }

        private bool _IsNearZero = false;
        /// <summary>
        /// близо до нулата
        /// </summary>
        public bool IsNearZero
        {
            get
            { return _IsNearZero; }
        }

        private bool _IsOverload = false;
        /// <summary>
        /// претоварване
        /// </summary>
        public bool IsOverload
        {
            get
            { return _IsOverload; }
        }

        private bool _IsStabilized = false;
        /// <summary>
        /// стабилизирана
        /// </summary>
        public bool IsStabilized
        {
            get
            { return _IsStabilized; }
        }

        private bool _IsWeightBelowMinimum = false;
        /// <summary>
        /// теглото е под минималното
        /// </summary>
        public bool IsWeightBelowMinimum
        {
            get
            { return _IsWeightBelowMinimum; }
        }

        private decimal _Value = 0;
        /// <summary>
        /// Измерената стойност
        /// </summary>
        public decimal Value
        {
            get
            { return _Value; }
        }

        /// <summary>
        /// Задава измерената стойност
        /// </summary>
        public void SetValue(string signValue, string poundsValue, string gramsValue)
        {
            // знак
            decimal sign = (signValue.Equals("-") ? -1 : 1);
            decimal pounds = 0;
            decimal grams = 0;
            Decimal.TryParse(poundsValue, out pounds);
            Decimal.TryParse(gramsValue, out grams);

            _Value = sign * (pounds + (grams / 1000));
        }

        /// <summary>
        /// Задава флаговете
        /// </summary>
        public void SetFlags(byte[] flagsValue)
        {
            System.Collections.BitArray bits = new System.Collections.BitArray(flagsValue);
            // бит 0 – 0/1 – индикатора показва тегло/тара
            _IsTare = bits[0];
            // bit 1 – 1== отрицателно тегло
            _IsNegativeWeight = bits[1];
            // bit 2 – 1== флаг близо до нулата
            _IsNearZero = bits[2];
            // bit 3 – 1== претоварване
            _IsOverload = bits[3];
            // bit 4 – 1== флаг стабилизирана
            _IsStabilized = bits[4];
            // bit 5 – 1== теглото е под минималното
            _IsWeightBelowMinimum = bits[4];
            // bit 6 – винаги = 1
            // bit 7 – 0 ( за 8-битовия протокол)
        }
    }
}
