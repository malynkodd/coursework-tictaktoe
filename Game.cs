using System;
using System.Windows.Forms;

namespace Alien_Invaders
{
    public class Game
    {
        public bool player1_turn = true;
        public int[,] boardValue = new int[3, 3];
      

        public Game()
        {
            player1_turn = true;
        }
        
        public int check_win()
        {
            // Check rows
            for (int i = 0; i < 3; ++i)
            {
                if (Convert.ToInt32(boardValue[i, 0]) == Convert.ToInt32(boardValue[i, 1]) &&
                    Convert.ToInt32(boardValue[i, 1]) == Convert.ToInt32(boardValue[i, 2]) &&
                    Convert.ToInt32(boardValue[i, 1]) != 0) {
                    return 1;
                }
            }

            // Check columns
            for (int i = 0; i < 3; ++i)
            {
                if (Convert.ToInt32(boardValue[0, i]) == Convert.ToInt32(boardValue[1, i]) &&
                    Convert.ToInt32(boardValue[1, i]) == Convert.ToInt32(boardValue[2, i]) &&
                    Convert.ToInt32(boardValue[2, i]) != 0)
                {
                    
                    return 1;
                }
            }

            // Check diagonals
            if (Convert.ToInt32(boardValue[0, 0]) == Convert.ToInt32(boardValue[1, 1]) &&
                Convert.ToInt32(boardValue[1, 1]) == Convert.ToInt32(boardValue[2, 2]) &&
                Convert.ToInt32(boardValue[2, 2]) != 0)
            {
                
                return 1;
            }
            else if (Convert.ToInt32(boardValue[0, 2]) == Convert.ToInt32(boardValue[1, 1]) &&
              Convert.ToInt32(boardValue[1, 1]) == Convert.ToInt32(boardValue[2, 0]) &&
              Convert.ToInt32(boardValue[2, 0]) != 0)
            {
                
                return 1;
            }

            // Check draw
            bool is_completed = true;
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (boardValue[i, j] == 0)
                    {
                        is_completed = false;
                     
                    }
                }
            }

            if (is_completed == true)
            {
                return -1;
            }
           
            return 0;
        }

        public int ValidMove(int row, int col)
        {
            return boardValue[row, col];
        }
        

        
    }
}