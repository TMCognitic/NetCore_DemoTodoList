using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Patterns.Mediator
{
    public class Messager<TMessage>
    {
        #region Pattern Singleton
        private static Messager<TMessage>? _instance;

        public static Messager<TMessage> Instance
        {
            get
            {
                //Coalesce d'affectation
                return _instance ??= new Messager<TMessage>();
            }
        }

        private Messager()
        {

        }
        #endregion

        public event Action<TMessage>? MessageHandler;

        public void Send(TMessage message)
        {
            MessageHandler?.Invoke(message);
        }
    }
}
