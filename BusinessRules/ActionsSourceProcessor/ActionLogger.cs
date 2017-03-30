using System;
using System.Collections.Generic;

namespace BusinessRules.ActionsSourceProcessor
{
    public class ActionLogger : IActionLogger
    {
        private static List<string> _loggedActions;

        public ActionLogger()
        {
            if ( _loggedActions == null )
                _loggedActions = new List<string>();            
        }

        public void ClearLog()
        {
            _loggedActions.Clear();
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
            _loggedActions.Add(text);
        }

        public string[] GetLog()
        {
            return _loggedActions.ToArray();
        }
    }
}
