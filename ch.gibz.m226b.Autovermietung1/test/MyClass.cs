using ch.gibz.m226b.Autovermietung1.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ch.gibz.m226b.Autovermietung1.test
{
    /*
         * public
         * private
         * protected
         * internal
         */

    public class MyClass : ITest
    {
        public string GetText => throw new NotImplementedException();

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetName()
        {
            throw new NotImplementedException();
        }
        
        public void SetValue(int a)
        {
            throw new NotImplementedException();
        }
    }
}
