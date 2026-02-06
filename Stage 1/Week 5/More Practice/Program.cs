using System;
using System.Collections.Generic;
namespace Week5MorePractice;
class Orc
{
    // STATIC: This belongs to the "Blueprint." 
    // There is only ONE of these for the whole game.
    public int TotalOrcCount = 0;
    // NON-STATIC: This belongs to the "House." 
    // Every Orc has its own unique health.
    public int health = 100;
    public Orc()
    {
        // Every time 'new Orc()' is called, we increment the shared counter
        TotalOrcCount++;
    }
    public void TakeDamage(int amount)
    {
        // This only affects the health of the SPECIFIC orc that was hit
        health -= amount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int num = -5;
        Console.WriteLine(Math.Abs(num));
    } //end of main
    
} // end of program

