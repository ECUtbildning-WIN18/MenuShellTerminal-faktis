﻿using MenuShellTerminal.Views;
using Domain;
using Services;

namespace MenuShellTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var dataBase = new Database();
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
