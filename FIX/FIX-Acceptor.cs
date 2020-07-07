using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickFix;

namespace FIX
{
    public class FIXAcceptor : MessageCracker, IApplication
    {
        ThreadedSocketAcceptor _acceptor;
        String _name;

        public FIXAcceptor()
        {
            _name = this.GetType().Name;
            SessionSettings settings = new SessionSettings(String.Format("{0}.cfg", _name));
            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            _acceptor = new ThreadedSocketAcceptor(
                this, 
                storeFactory, 
                settings, 
                logFactory
            );
        }

        public void start()
        {
            _acceptor.Start();
            while (true)
            {
                System.Console.WriteLine(_name);
                System.Threading.Thread.Sleep(1000);
            }
            _acceptor.Stop();
        }


        public void FromApp(Message msg, SessionID sessionID)
        {
            Console.WriteLine("{0} FromApp {1}, {2}", _name, sessionID.ToString(), msg.ToString());
        }
        public void OnCreate(SessionID sessionID)
        {
            Console.WriteLine("{0} OnCreate {1}", _name, sessionID.ToString());
        }
        public void OnLogout(SessionID sessionID)
        {
            Console.WriteLine("{0} OnLogout {1}", _name, sessionID.ToString());
        }
        public void OnLogon(SessionID sessionID)
        {
            Console.WriteLine("{0} OnLogon {1}", _name, sessionID.ToString());
        }
        public void FromAdmin(Message msg, SessionID sessionID)
        {
            Console.WriteLine("{0} FromAdmin {1}, {2}", _name, sessionID.ToString(), msg.ToString());
        }
        public void ToAdmin(Message msg, SessionID sessionID)
        {
            Console.WriteLine("{0} ToAdmin {1}, {2}", _name, sessionID.ToString(), msg.ToString());
        }
        public void ToApp(Message msg, SessionID sessionID)
        {
            Console.WriteLine("{0} ToApp {1}, {2}", _name, sessionID.ToString(), msg.ToString());
        }
    }
}
