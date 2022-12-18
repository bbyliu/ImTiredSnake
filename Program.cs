﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Walls walls = new Walls(80, 25);
            walls.Draw();
	
            Point p = new Point(4, 5, 'D');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, 'О');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            Console.ReadLine();
        }
        
    }
}