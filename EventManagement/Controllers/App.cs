using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EventManagement.Controllers
{
    public class App
    {
        InputController inp;

        public void print()
        {
            inp = new InputController();

            DataTable dt = inp.getInput();

            Console.WriteLine(dt.DisplayExpression);
        
        }
        
    }
}