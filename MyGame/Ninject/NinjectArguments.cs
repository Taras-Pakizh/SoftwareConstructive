using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Planning.Targets;

namespace MyGame
{
    class NinjectArguments
    {
        private Parameter[] _parameters;

        public NinjectArguments(params object[] parameters)
        {
            _parameters = new Parameter[parameters.Length];
            for(int i = 0; i < parameters.Length; ++i)
            {
                _parameters[i] = new Parameter("arg" + i, parameters[i], false);
            }
        }

        public Parameter[] GetValues()
        {
            return _parameters;
        }
    }
}
