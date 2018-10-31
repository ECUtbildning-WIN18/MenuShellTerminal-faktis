﻿using MenuShellTerminal.Views;
using Domain;


namespace MenuShellTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var dataBase = new Database();
            Sql sql = new Sql();
            sql.InitSql();
            var running = true;
            View view;
            view = new LoginView();
            while(running)
            {
                view = view.ViewIt();
            }
        }
    }
}
