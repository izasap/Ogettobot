using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogettobot
{
    public class Distribution
    {
        public void Distribut()
        {
            Random rand = new Random();
            int count = 0;
            string[] players = File.ReadAllLines(@"Users\allplayers.txt");
            string[] disctrubplayers = File.ReadAllLines(@"Users\allplayers.txt");

            for (int i = 0; i < players.Length; i++)
            {
                int n = rand.Next(players.Length);

                if (players[i] != disctrubplayers[n] && players[i] != "" && disctrubplayers[n] != "")
                {
                    if (File.ReadAllLines($@"Users\{players[i]}.txt").Length < 4)
                    {
                        File.WriteAllText($@"Users\{players[i]}.txt", File.ReadAllText($@"Users\{players[i]}.txt") + "\n" + disctrubplayers[n]);
                        disctrubplayers[n] = "";
                    }

                    else
                    {
                        string[] stats = File.ReadAllLines($@"Users\{players[i]}.txt");
                        stats[3] = disctrubplayers[n];
                        File.WriteAllLines($@"Users\{players[i]}.txt", stats);
                        disctrubplayers[n] = "";
                    }
                }

                else if (players[i] != "")
                    i--;
            }
        }
    }
}
