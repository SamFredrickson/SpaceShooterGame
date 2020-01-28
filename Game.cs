using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooterGame
{
    public partial class Game : Form
    {
        public Game(string difficulty, string playerName)
        {
            InitializeComponent();
            label_name.Text = string.Format("Игрок: {0}", playerName);
            label_diff.Text = string.Format("Сложность: {0}", difficulty);
            SetDiff(difficulty);
            _difficulty = difficulty;
            _playername = playerName;
        }

        //+++++++++++++++ Global Variables +++++++++++++++++++++++++ //
        Graphics g;
        Menu menu = new Menu();
        Random rand = new Random();
        SolidBrush black = new SolidBrush(Color.Black);
        SolidBrush red = new SolidBrush(Color.Red);
        Ship playerShip = new Ship(0, 0, 100, 100, 100, 10);
        static int xNumberOfFighters = 4, yNumberOfFighters = 4;
        Ship[,] fighter = new Ship[xNumberOfFighters, yNumberOfFighters];
        List<Missile> playermissiles = new List<Missile>();
        List<Missile> fighterMissiles = new List<Missile>();
        List<Missile> SDmissiles = new List<Missile>();
        List<Explotion> explotion = new List<Explotion>();
        List<PowerUp> powerUp = new List<PowerUp>();
        int numberOfStarDistroyers = 4;
        List<Ship> starDistroyer = new List<Ship>();
        List<Ship> deathStar = new List<Ship>();
        int timer = 0;
        bool playerShipFireCannons = false;
        int cannonCount = 3;
        int powerUPTimer = 900;
        int enemyDamage = 10;
        int seconds = 0;
        int minutes = 0;
        int hours = 0;
        string _difficulty;
        string _playername;
        DataManager dm = new DataManager();

        bool moveUp = false, moveDown = false, moveLeft = false, moveRight = false, isPause = false;

        Bitmap fighterOne = new Bitmap("Resources/Fighter1.png");
        Bitmap fighterTwo = new Bitmap("Resources/Fighter2.png");
        Bitmap explotionOne = new Bitmap("Resources/fireExplotion1.png");
        Bitmap explotionTwo = new Bitmap("Resources/fireExplotion2.png");
        Bitmap playerShipOne = new Bitmap("Resources/SpaceShip1.png");
        Bitmap playerShipTwo = new Bitmap("Resources/SpaceShip2.png");
        Bitmap missile = new Bitmap("Resources/Missile.png");
        Bitmap fireBall = new Bitmap("Resources/FireBall.png");
        Bitmap starDistroyerPic = new Bitmap("Resources/startDestroyer1.png");
        Bitmap starDistroyerBlank = new Bitmap("Resources/startDestroyerBlank.png");
        Bitmap powerUpPic = new Bitmap("Resources/PowerUp.png");
        Bitmap deathStarPic = new Bitmap("Resources/DeathStar1.png");
        Bitmap deathStarBlank = new Bitmap("Resources/DeathStarBlank.png");


       

        // +++++++++++++++++++++ Функции инициализации объектов ++++++++++++++++++++ //
        private void buildFighters()
        {
            float yLocation = 40;
            for (int x = 0; x < xNumberOfFighters; x++)
            {
                for (int y = 0; y < yNumberOfFighters; y++)
                {
                    fighter[x, y] = new Ship(x, y, 900, yLocation, 100, 10);
                    yLocation = yLocation + 50;
                }
            }
        }
        private void moveFighters()
        {
            
            for (int x = 0; x < xNumberOfFighters; x++)
            {
                for (int y = 0; y < yNumberOfFighters; y++)
                {
                    g.FillRectangle(black, fighter[x, y].xGraphicLocation, fighter[x, y].yGraphicLocation, 25, 25);
                    fighter[x, y].xGraphicLocation = fighter[x, y].xGraphicLocation - rand.Next(5, 15);
                    fighter[x, y].yGraphicLocation = fighter[x, y].yGraphicLocation - rand.Next(-10, 10);
                    if (fighter[x,y].xGraphicLocation < 100)
                    {
                        fighter[x,y].xGraphicLocation = 1200;
                        fighter[x, y].yGraphicLocation = rand.Next(100, 400);
                        fighter[x, y].shields = 100;
                    }
                
                }
            }
        }
        private void buildStarDistroyers()
        {
            int xLoc = 700;
            int yLoc = 30;
            for (int i = 0; i < numberOfStarDistroyers; i++)
            {
                starDistroyer.Add(new Ship(1, 1, xLoc, yLoc, 1000, 20));
                xLoc = xLoc + 300;
                yLoc = yLoc + 110;
            }
        }
        private void moveStarDistroyers()
        {
            for (int i = 0; i < numberOfStarDistroyers; i++)
            {
                g.DrawImage(starDistroyerBlank, starDistroyer[i].xGraphicLocation - 1, starDistroyer[i].yGraphicLocation - 1, 152, 72);
                starDistroyer[i].xGraphicLocation = starDistroyer[i].xGraphicLocation - 5;
                if (starDistroyer[i].xGraphicLocation < -150)
                {
                    starDistroyer[i].xGraphicLocation = 1200;
                    starDistroyer[i].shields = 1000;
                }
                g.DrawImage(starDistroyerPic, starDistroyer[i].xGraphicLocation, starDistroyer[i].yGraphicLocation, 150, 70);
            }
        }
        private void MovePowerUp()
        {
            for (int p = 0; p < powerUp.Count(); p++)
            {
                g.FillRectangle(black, powerUp[p].x, powerUp[p].y, 50, 50);
                g.DrawImage(powerUp[p].picture, powerUp[p].x, powerUp[p].y, 50, 50);
            }
        }
        private void moveDeathStar()
        {
            for (int i = 0; i < deathStar.Count(); i++)
            {
                g.DrawImage(deathStarBlank, deathStar[i].xGraphicLocation, deathStar[i].yGraphicLocation, 150, 150);
                deathStar[i].xGraphicLocation = deathStar[i].xGraphicLocation - 2;
                g.DrawImage(deathStarPic, deathStar[i].xGraphicLocation, deathStar[i].yGraphicLocation, 150, 150);
                if (deathStar[i].xGraphicLocation < -200)
                {
                    deathStar.Remove(deathStar[i]);
                }
            }          
        }

        // +++++++++++++++++++++ Функции для установки сложности ++++++++++++++++++++ //
        private void SetEasy()
        {
            numberOfStarDistroyers = 4;
            enemyDamage = 10;
             
        }
        private void SetMedium()
        {
            numberOfStarDistroyers = 5;
            enemyDamage = 20;            
        }

        private void SetHard()
        {
            numberOfStarDistroyers = 6;
            enemyDamage = 25;             
        }

        private void SetVeryHard()
        {
            numberOfStarDistroyers = 7;
            enemyDamage = 40;             
        }

        private void SetDiff(string diff)
        {
            switch (diff)
            {
                case "Легко": SetEasy(); break;
                case "Средне": SetMedium(); break;
                case "Тяжело": SetHard(); break;
                case "Очень тяжело": SetVeryHard(); break;
            }
        }

        // ++++++++++++++++++++++ Функции отрисовки ++++++++++++++++++++++++++++++++++ //
        private void drawPlayerShipShileds()
        {
            g.FillRectangle(red, 5, 5, 110, 20);
            g.FillRectangle(black, 10, 10, playerShip.shields, 10);
        }
        private void drawPlayerShip(int i)
        {
            if (i == 1)
            {
                g.DrawImage(playerShipOne, playerShip.xGraphicLocation, playerShip.yGraphicLocation, 50, 50);
            }
            else if (i == 2)
            {
                g.DrawImage(playerShipTwo, playerShip.xGraphicLocation, playerShip.yGraphicLocation, 50, 50);
            }
            
        }
        private void drawFighters(int i)
        {
            for (int x = 0; x < xNumberOfFighters; x++)
            {
                for (int y = 0; y < yNumberOfFighters; y++)
                {
                    if (i == 1)
                    {
                        g.DrawImage(fighterOne, fighter[x, y].xGraphicLocation, fighter[x, y].yGraphicLocation, 25, 25);
                    }
                    else if (i == 2)
                    {
                        g.DrawImage(fighterTwo, fighter[x, y].xGraphicLocation, fighter[x, y].yGraphicLocation, 25, 25);
                    }
                }
            }            
        }
        private void drawExplotions()
        {
            for (int i = 0; i < explotion.Count(); i++)
            {
                g.FillRectangle(black, explotion[i].xLocation - 20, explotion[i].yLocation - 20, 50, 50);
                explotion[i].count++;
                if (explotion[i].count % 2 == 0)
                {
                    g.DrawImage(explotionOne, explotion[i].xLocation, explotion[i].yLocation, explotion[i].xLength, explotion[i].yHeight);
                }
                else if (explotion[i].count % 2 == 1)
                {
                    g.DrawImage(explotionTwo, explotion[i].xLocation, explotion[i].yLocation, explotion[i].xLength, explotion[i].yHeight);
                }
                if (explotion[i].count == 10)
                {
                    g.FillRectangle(black, explotion[i].xLocation, explotion[i].yLocation, explotion[i].xLength, explotion[i].yHeight);
                    explotion.Remove(explotion[i]);
                }
            }
        }
        private void drawFighterMissiles()
        {
            for (int m = 0; m < fighterMissiles.Count; m++)
            {
                g.FillRectangle(black, fighterMissiles[m].xGraphicLocation, fighterMissiles[m].yGraphicLocation, 12, 12);
                fighterMissiles[m].xGraphicLocation = fighterMissiles[m].xGraphicLocation - 20;
                g.DrawImage(fighterMissiles[m].picture, fighterMissiles[m].xGraphicLocation, fighterMissiles[m].yGraphicLocation, 12, 12);
                fighterMissiles[m].distanceTraveled++;
                if (fighterMissiles[m].distanceTraveled > 40)
                {
                    g.FillRectangle(black, fighterMissiles[m].xGraphicLocation, fighterMissiles[m].yGraphicLocation, 12, 12);
                    fighterMissiles.Remove(fighterMissiles[m]);
                    break;
                }
            }
        }
        private void drawstarDistroyerMissiles()
        {
            for (int m = 0; m < SDmissiles.Count; m++)
            {
                g.FillRectangle(black, SDmissiles[m].xGraphicLocation, SDmissiles[m].yGraphicLocation, 40, 40);
                SDmissiles[m].xGraphicLocation = SDmissiles[m].xGraphicLocation - 10;
                g.DrawImage(SDmissiles[m].picture, SDmissiles[m].xGraphicLocation, SDmissiles[m].yGraphicLocation, 40, 40);
                SDmissiles[m].distanceTraveled++;
                if (SDmissiles[m].distanceTraveled > 80)
                {
                    g.FillRectangle(black, SDmissiles[m].xGraphicLocation, SDmissiles[m].yGraphicLocation, 40, 40);
                    SDmissiles.Remove(SDmissiles[m]);
                    break;
                }
            }           
        }
        private void drawPowerUps()
        {
            for (int x = 0; x < powerUp.Count(); x++)
            {
                g.DrawImage(powerUp[x].picture, powerUp[x].x, powerUp[x].y, 50, 50);
            }
        }
        private void drawPlayerInfo(bool showOrhide)
        {
            if (!showOrhide)
            {
                label_name.Hide();
                label_diff.Hide();
                label_timer.Hide();
            }
            else
            {
                label_name.Show();
                label_diff.Show();
                label_timer.Show();
            }
        }
        private void drawPlayerPause(bool isESC)
        {
            if (isESC)
            {
                label_name.Hide();
                label_diff.Hide();
                label_timer.Hide();
                label_pause_game.Hide();
                gameTimer.Enabled = true;
                timer_record.Enabled = true;
                isPause = false;
            }
            else
            {
                label_name.Show();
                label_diff.Show();
                label_timer.Show();
                label_pause_game.Show();
                gameTimer.Enabled = false;
                timer_record.Enabled = false;
                isPause = true;
            }
        }

        // ++++++++++++++++++ Клавиши управления +++++++++++++++++++++++++++++++++++++++++++++++ //
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) moveUp = true;
            else if (e.KeyCode == Keys.S) moveDown = true;
            else if (e.KeyCode == Keys.A) moveLeft = true;
            else if (e.KeyCode == Keys.D) moveRight = true;
            if (e.KeyCode == Keys.Space) playerShipFireCannons = true;
            if (e.KeyCode == Keys.Tab) drawPlayerInfo(true);
            if (e.KeyCode == Keys.Escape) drawPlayerPause(isPause);

            if(gameTimer.Enabled != true)
            {
                if(e.KeyCode == Keys.Enter)
                {
                    this.Hide();
                    menu.Show();
                }
            }

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) moveUp = false;
            else if (e.KeyCode == Keys.S) moveDown = false;
            else if (e.KeyCode == Keys.A) moveLeft = false;
            else if (e.KeyCode == Keys.D) moveRight = false;
            if (e.KeyCode == Keys.Space) playerShipFireCannons = false;
            if (e.KeyCode == Keys.Tab) drawPlayerInfo(false);
        }


        // ++++++++++++++++++++ Снаряды / Аттаки / Столкновения ++++++++++++++++++++//
        private void fireShipMissiles(int cannonCount)
        {
            if (cannonCount < 1) cannonCount = 1;
            if (cannonCount > 3) cannonCount = 3; 
            cannonCount = 3;
            if (cannonCount == 1)
            {
                for (int i = 0; i < playermissiles.Count(); i++)
                {
                    g.FillRectangle(black, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation, 14, 8);
                    playermissiles[i].xGraphicLocation = playermissiles[i].xGraphicLocation + 20;
                    g.DrawImage(playermissiles[i].picture, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation, 14, 8);
                    playermissiles[i].distanceTraveled++;
                    if (playermissiles[i].distanceTraveled > 30)
                    {
                        g.FillRectangle(black, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation, 14, 8);
                        playermissiles.Remove(playermissiles[i]);
                    }
                }
            }
            else if (cannonCount == 2)
            {
                for (int i = 0; i < playermissiles.Count(); i++)
                {
                    g.FillRectangle(black, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation - 15, 14, 8);             
                    g.FillRectangle(black, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation + 15, 14, 8);
                    playermissiles[i].xGraphicLocation = playermissiles[i].xGraphicLocation + 20;
                    g.DrawImage(playermissiles[i].picture, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation - 15, 14, 8);                   
                    g.DrawImage(playermissiles[i].picture, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation + 15, 14, 8);
                    playermissiles[i].distanceTraveled++;
                    if (playermissiles[i].distanceTraveled > 30)
                    {
                        g.FillRectangle(black, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation - 15, 14, 8);             
                        g.FillRectangle(black, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation + 15, 14, 8);
                        playermissiles.Remove(playermissiles[i]);
                    }
                }
            }
            else if (cannonCount == 3)
            {
                for (int i = 0; i < playermissiles.Count(); i++)
                {
                    g.FillRectangle(black, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation -15, 14, 8);
                    g.FillRectangle(black, playermissiles[i].xGraphicLocation + 10, playermissiles[i].yGraphicLocation, 14, 8);
                    g.FillRectangle(black, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation + 15, 14, 8);
                    playermissiles[i].xGraphicLocation = playermissiles[i].xGraphicLocation + 20;
                    g.DrawImage(playermissiles[i].picture, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation -15, 14, 8);
                    g.DrawImage(playermissiles[i].picture, playermissiles[i].xGraphicLocation + 10, playermissiles[i].yGraphicLocation, 14, 8);
                    g.DrawImage(playermissiles[i].picture, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation + 15, 14, 8);
                    playermissiles[i].distanceTraveled++;
                    if (playermissiles[i].distanceTraveled > 30)
                    {
                        g.FillRectangle(black, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation -15, 14, 8);
                        g.FillRectangle(black, playermissiles[i].xGraphicLocation + 10, playermissiles[i].yGraphicLocation, 14, 8);
                        g.FillRectangle(black, playermissiles[i].xGraphicLocation, playermissiles[i].yGraphicLocation + 15, 14, 8);
                        playermissiles.Remove(playermissiles[i]);
                    }
                }
            }
        }
        private void checkPlayerShipWithFighterColition()
        {
            for (int x = 0; x < xNumberOfFighters; x++)
            {
                for (int y =0; y < yNumberOfFighters; y++)
                {                    
                    if (playerShip.xGraphicLocation + 50 > fighter[x, y].xGraphicLocation && fighter[x, y].xGraphicLocation + 25 > playerShip.xGraphicLocation &&
                        playerShip.yGraphicLocation + 50 > fighter[x, y].yGraphicLocation && fighter[x, y].yGraphicLocation + 25 > playerShip.yGraphicLocation)
                    {
                        explotion.Add(new Explotion(playerShip.xGraphicLocation, playerShip.yGraphicLocation, 30, 30, 1));
                        playerShip.shields = playerShip.shields - 10;
                        timer = 0;
                        cannonCount--;
                        break;

                    }                   
                }
            }
        }
        private void checkPlayerMissileColitionWithFighters()
        {
            bool breakOut = false;
            for (int m = 0; m < playermissiles.Count; m++)
            {
                for (int x = 0; x < xNumberOfFighters; x++)
                {
                    for (int y = 0; y < yNumberOfFighters; y++)
                    {
                    
                        if (playermissiles[m].xGraphicLocation + 10 > fighter[x, y].xGraphicLocation && fighter[x,y].xGraphicLocation + 150 > playermissiles[m].xGraphicLocation &&
                            playermissiles[m].yGraphicLocation + 20 > fighter[x, y].yGraphicLocation && fighter[x,y].yGraphicLocation + 20 > playermissiles[m].yGraphicLocation)
                        {
                            explotion.Add(new Explotion(fighter[x,y].xGraphicLocation, fighter[x,y].yGraphicLocation, 30, 30, 1));
                            g.FillRectangle(black, playermissiles[m].xGraphicLocation, playermissiles[m].yGraphicLocation, 30, 30);
                            fighter[x, y].shields = fighter[x, y].shields - 10 * cannonCount;
                            if (fighter[x, y].shields < 0)
                            {
                                fighter[x,y].xGraphicLocation = 2000;
                                fighter[x,y].shields = 100;
                            }
                            playermissiles.Remove(playermissiles[m]);
                            breakOut = true;
                        }
                        if (breakOut == true) break;
                    }
                    if (breakOut == true) break;
                }
            }
        }
        private void checkPlayerShipWithfighterMissileColition()
        {
            for (int fm = 0; fm < fighterMissiles.Count(); fm++)
            {
                if (playerShip.xGraphicLocation + 50 > fighterMissiles[fm].xGraphicLocation && fighterMissiles[fm].xGraphicLocation + 25 > playerShip.xGraphicLocation &&
                        playerShip.yGraphicLocation + 50 > fighterMissiles[fm].yGraphicLocation && fighterMissiles[fm].yGraphicLocation + 25 > playerShip.yGraphicLocation)
                {
                    explotion.Add(new Explotion(playerShip.xGraphicLocation, playerShip.yGraphicLocation, 30, 30, 0));
                   
                        playerShip.shields = playerShip.shields - enemyDamage;
                        timer = 0;
                        cannonCount--;                       
                        break;
                }
            }
        }
        private void checkPLayerShipWithStarDistroyerColition()
        {
            for (int i = 0; i < numberOfStarDistroyers; i++)
            {
                if (playerShip.xGraphicLocation + 50 > starDistroyer[i].xGraphicLocation && starDistroyer[i].xGraphicLocation + 150 > playerShip.xGraphicLocation &&
                        playerShip.yGraphicLocation + 50 > starDistroyer[i].yGraphicLocation && starDistroyer[i].yGraphicLocation + 70 > playerShip.yGraphicLocation)
                {
                    explotion.Add(new Explotion(playerShip.xGraphicLocation, playerShip.yGraphicLocation, 30, 30, 0));
                    playerShip.shields = playerShip.shields - 10;
                    timer = 0;
                    cannonCount--;
                    break;
                }
            }
        }

        private void checkPlayerShildIsLessThenZeroOrEqual()
        {
            if(playerShip.shields <= 0)
            {
                gameTimer.Enabled = false;
                label_gameover.Show();
                label_time_gameover.Show();
                label_exit.Show();
                timer_record.Enabled = false;

                dm.Add(_playername, _difficulty, seconds, minutes, hours);
            }
        }

        private void checkPlayerMissilesWithStarDistroyerColition()
        {
            for (int m = 0; m < playermissiles.Count(); m++)
            {
                for (int s = 0; s < starDistroyer.Count(); s++)
                {
                    if (starDistroyer[s].xGraphicLocation + 50 < playermissiles[m].xGraphicLocation && playermissiles[m].xGraphicLocation < starDistroyer[s].xGraphicLocation + 200 &&
                        starDistroyer[s].yGraphicLocation + 60 > playermissiles[m].yGraphicLocation && playermissiles[m].yGraphicLocation + 50 > starDistroyer[s].yGraphicLocation)
                    {
                        explotion.Add(new Explotion(starDistroyer[s].xGraphicLocation, starDistroyer[s].yGraphicLocation + 15, 50, 50, 0));
                        starDistroyer[s].shields = starDistroyer[s].shields - 10 * cannonCount;
                        playermissiles.Remove(playermissiles[m]);
                        if (starDistroyer[s].shields < 1)
                        {
                            explotion.Add(new Explotion(starDistroyer[s].xGraphicLocation, starDistroyer[s].yGraphicLocation, 200, 150, -10));
                            g.DrawImage(starDistroyerBlank, starDistroyer[s].xGraphicLocation - 25, starDistroyer[s].yGraphicLocation - 13, 150, 70);
                            starDistroyer[s].shields = 1000;
                            starDistroyer[s].xGraphicLocation = 2000;
                        }
                        break;
                    }
                }
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            g = pnlGameBoard.CreateGraphics();
            gameTimer.Enabled = true;
            buildFighters();
            buildStarDistroyers();
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Show();        
        }

        private void label_time_gameover_Click(object sender, EventArgs e)
        {

        }

        private void checkPLayerShipWithStarDistroyerMissileColition()
        {
            for (int m = 0; m < SDmissiles.Count(); m++)
            {
                if (playerShip.xGraphicLocation + 50 > SDmissiles[m].xGraphicLocation && SDmissiles[m].xGraphicLocation + 30 > playerShip.xGraphicLocation &&
                    playerShip.yGraphicLocation + 50 > SDmissiles[m].yGraphicLocation && SDmissiles[m].yGraphicLocation + 30 > playerShip.yGraphicLocation)
                {
                    timer = 0;
                    explotion.Add(new Explotion(playerShip.xGraphicLocation, playerShip.yGraphicLocation, 40, 40, 0));
                    playerShip.shields = playerShip.shields - (enemyDamage + 10);
                    cannonCount--;
                    break;
                }
            }
        }
        private void checkPlayerShipWithPowerUpColition()
        {
            for (int i = 0; i < powerUp.Count(); i++)
            {
                if (playerShip.xGraphicLocation + 50 > powerUp[i].x && powerUp[i].x + 50 > playerShip.xGraphicLocation &&
                    playerShip.yGraphicLocation + 50 > powerUp[i].y && powerUp[i].y + 50 > playerShip.yGraphicLocation)
                {
                    
                    playerShip.shields = playerShip.shields + powerUp[i].shields;
                    cannonCount = cannonCount + powerUp[i].cannonCount;
                    g.FillRectangle(black, powerUp[i].x, powerUp[i].y, 50, 50);
                    powerUp.Remove(powerUp[i]);
                    break;

                }
            }
        }
        private void checkPLayerMissilesWithDeathStar()
        {
            for (int s = 0; s < deathStar.Count(); s++)
            {
                for (int m = 0; m < playermissiles.Count; m++)
                {
                    if (deathStar[s].xGraphicLocation + 150 > playermissiles[m].xGraphicLocation + 40 && playermissiles[m].xGraphicLocation + 0 > deathStar[s].xGraphicLocation &&
                        deathStar[s].yGraphicLocation + 150 > playermissiles[m].yGraphicLocation + 40 && playermissiles[m].yGraphicLocation + 30 > deathStar[s].yGraphicLocation)
                    {
                        explotion.Add(new Explotion(deathStar[s].xGraphicLocation, deathStar[s].yGraphicLocation + 30, 80, 80, -5));
                        playermissiles.Remove(playermissiles[m]);
                        deathStar[s].shields = deathStar[s].shields - 10 * cannonCount;
                        if (deathStar[s].shields < 1)
                        {
                            explotion.Add(new Explotion(deathStar[s].xGraphicLocation - 25, deathStar[s].yGraphicLocation - 25, 250, 250, -5));
                            deathStar.Remove(deathStar[s]);
                        }
                        break;
                    }
                }
            }
        }

        // ++++++++++++++++++++++++ Игровые таймеры +++++++++++++++++++++++++++++++++++++++ //
        private void timer_record_Tick(object sender, EventArgs e)
        {
            string sec = seconds.ToString();
            string min = minutes.ToString();
            string h = hours.ToString();

            if (seconds >= 60)
            {               
                seconds = 0;
                sec = seconds.ToString();
                minutes++;
            }
            if (minutes >= 60)
            {              
                minutes = 0;
                min = minutes.ToString();
                hours++;
            }

            if (seconds <= 9) sec = $"0{sec}";
            else sec = seconds.ToString();
            if (hours <= 9) h = $"0{h}";
            else h = hours.ToString();
            if (minutes <= 9) min = $"0{min}";
            else min = minutes.ToString();

            seconds++;
            label_timer.Text = string.Format("Время: {0}:{1}:{2}", h, min, sec);
            label_time_gameover.Text = string.Format("{0}:{1}:{2}", h, min, sec);

        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            timer++;
            powerUPTimer++;
            if (timer % 4 == 1)
            {
                moveFighters();
                drawPlayerShip(1);
                drawFighters(1);
                drawPlayerShipShileds();
                drawPowerUps();
                MovePowerUp();
                moveDeathStar();
            }
            if (timer % 4 == 3)
            {
                moveStarDistroyers();
                drawPlayerShip(2);
                drawFighters(2);
            }
            if (cannonCount < 1) cannonCount = 1; 
            if (playerShip.shields > 100) playerShip.shields = 100;


            // Below is for player coltrols
            if (moveUp == true && playerShip.yGraphicLocation > 0)
            {
                g.FillRectangle(black, playerShip.xGraphicLocation, playerShip.yGraphicLocation, 50, 50);
                playerShip.yGraphicLocation = playerShip.yGraphicLocation - 10;
                drawPlayerShip(1);
            }
            if (moveDown == true && playerShip.yGraphicLocation < 500)
            {
                g.FillRectangle(black, playerShip.xGraphicLocation, playerShip.yGraphicLocation, 50, 50);
                playerShip.yGraphicLocation = playerShip.yGraphicLocation + 10;
                drawPlayerShip(1);
            }
            if (moveLeft == true && playerShip.xGraphicLocation > 0)
            {
                g.FillRectangle(black, playerShip.xGraphicLocation, playerShip.yGraphicLocation, 50, 50);
                playerShip.xGraphicLocation = playerShip.xGraphicLocation - 10;
                drawPlayerShip(1);
            }
            if (moveRight == true && playerShip.xGraphicLocation < 950)
            {
                g.FillRectangle(black, playerShip.xGraphicLocation, playerShip.yGraphicLocation, 50, 50);
                playerShip.xGraphicLocation = playerShip.xGraphicLocation + 10;
                drawPlayerShip(1);
            }

            // below is for missle graphics and colitions
            if (playerShipFireCannons == true && timer % 3 == 0)
            {
                playermissiles.Add(new Missile(playerShip.xGraphicLocation + 50, playerShip.yGraphicLocation + 22, true, cannonCount, 0, missile));              
            }
            fireShipMissiles(cannonCount);
            checkPlayerMissileColitionWithFighters();
            checkPlayerShildIsLessThenZeroOrEqual();
            checkPlayerMissilesWithStarDistroyerColition();
            checkPlayerShipWithPowerUpColition();
            drawExplotions();
            checkPLayerMissilesWithDeathStar();
            if (timer > 20)
            {
                checkPlayerShipWithFighterColition();
                checkPlayerShipWithfighterMissileColition();
                checkPLayerShipWithStarDistroyerColition();
                checkPLayerShipWithStarDistroyerMissileColition();
            }
            if (timer % 10 == 0) // shoots fighter cannons
            {
                float x = fighter[rand.Next(0, xNumberOfFighters), (rand.Next(0, yNumberOfFighters))].xGraphicLocation - 10;
                float y = fighter[rand.Next(0, xNumberOfFighters), (rand.Next(0, yNumberOfFighters))].yGraphicLocation + 12;
                fighterMissiles.Add(new Missile(x, y, true, 1, 0, fireBall));               
            }
            if (timer % 2 == 0)
            {
                drawFighterMissiles();
                drawstarDistroyerMissiles();
            }
            if (timer % 50 == 0)
            {
                int x = rand.Next(0, numberOfStarDistroyers);
                SDmissiles.Add(new Missile(starDistroyer[x].xGraphicLocation - 30, starDistroyer[x].yGraphicLocation + 25, true, 1, 0, fireBall)); 
            }
            if (powerUPTimer % 300 == 0)
            {
                int x = rand.Next(200, 700);
                int y = rand.Next(100, 350);
                int shields = rand.Next(10, 50);
                int cannons = rand.Next(1, 2);
                powerUp.Add(new PowerUp(x, y, shields, cannons, powerUpPic));               
            }
            if (powerUPTimer % 1200 == 0)
            {
                deathStar.Add(new Ship(1, 1, 1000, 200, 2000, 10));
            }
                     
        }
    }
}
