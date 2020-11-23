using System;
using System.Collections.Generic;
using System.Text;

namespace ch.gibz.m226b.Autovermietung1.Interface
{
    public interface ITest
    {
        string GetText { get; }

        string Name { get; set; }

        void SetValue(int a);

        string GetName();

        //KEINE FELDER
        //int localValue;

        static int ConstantVALUE = 1;
    }
}
