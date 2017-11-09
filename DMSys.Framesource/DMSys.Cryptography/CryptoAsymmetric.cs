using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DMSys.Cryptography
{
    public partial class CryptoAsymmetric : Component
    {
        public CryptoAsymmetric()
        {
            InitializeComponent();
        }
        
        public enum CryptoTypes
        {
                    DSA
        }
        
        public CryptoAsymmetric(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
