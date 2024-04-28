using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class frmMain : Form
    {
        enum enWinner { Player1, Player2, Computer, Draw, enProgress };
        enum enPlayer { Player1, Player2, Computer };
        enum enMode { vsFriend, vsComputer };

        enMode Mode = enMode.vsFriend;
        enPlayer PlayerTurn = enPlayer.Player1;
        stGameStatus GameStatus;
        struct stGameStatus
        {
            public short PlayCounter;
            public enWinner Winner;
            public bool GameOver;
            public int CounterPlayer1Winner;
            public int CounterPlayer2Winner;
            public int CounterComputerWinner;

        }

        void GameEnd()
        {
            lblTurn.Text = "Game Over -)";
            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player1";
                    lblPlayer1.Text = GameStatus.CounterPlayer1Winner.ToString();
                    break;
                case enWinner.Player2:
                    lblWinner.Text = "Player2";
                    lblPlayer2.Text = GameStatus.CounterPlayer2Winner.ToString();

                    break;
                case enWinner.Computer:
                    lblWinner.Text = "Computer";
                    lblComputer.Text = GameStatus.CounterComputerWinner.ToString();
                    break;

                default:
                    lblWinner.Text = "Draw";
                    break;
            }
            if (MessageBox.Show(lblWinner.Text.ToString(), "Game Status", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                ResetGame();
            }

        }

        bool CheckValue(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn2.Tag.ToString() == btn1.Tag.ToString() && btn3.Tag.ToString() == btn1.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;
                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.GameOver = true;
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.CounterPlayer1Winner++;

                    GameEnd();
                    return true;
                }
                else
                {
                    if (Mode == enMode.vsComputer)
                    {
                        GameStatus.GameOver = true;
                        GameStatus.Winner = enWinner.Computer;
                        GameStatus.CounterComputerWinner++;
                        GameEnd();
                        return true;
                    }
                    GameStatus.GameOver = true;
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.CounterPlayer2Winner++;
                    GameEnd();
                    return true;
                }

            }


            GameStatus.GameOver = false;


            return false;
        }
        void CheckWinner()
        {
            if (CheckValue(button1, button2, button3))
                return;
            if (CheckValue(button1, button4, button7))
                return;
            if (CheckValue(button1, button5, button9))
                return;
            if (CheckValue(button2, button5, button8))
                return;
            if (CheckValue(button4, button5, button6))
                return;
            if (CheckValue(button3, button6, button9))
                return;
            if (CheckValue(button7, button8, button9))
                return;
            if (CheckValue(button3, button5, button7))
                return;
            if (Mode == enMode.vsComputer && PlayerTurn == enPlayer.Computer)
            {
                _ComputerMove();
                return;
            }
            if (GameStatus.PlayCounter == 9)
            {
                GameStatus.Winner = enWinner.Draw;
                GameStatus.GameOver = true;
                GameEnd();
            }


        }
        void ChangeImage(Button Btn)
        {
            if (Btn.Tag.ToString() == "?")
            {
                if (Mode == enMode.vsFriend)
                {
                    switch (PlayerTurn)
                    {
                        case enPlayer.Player1:
                            PlayerTurn = enPlayer.Player2;
                            Btn.Image = Resources.X;
                            Btn.Tag = "X";
                            GameStatus.PlayCounter++;
                            lblTurn.Text = PlayerTurn.ToString();
                            CheckWinner();
                            break;

                        case enPlayer.Player2:
                            PlayerTurn = enPlayer.Player1;
                            Btn.Image = Resources.O;
                            Btn.Tag = "O";
                            GameStatus.PlayCounter++;
                            lblTurn.Text = PlayerTurn.ToString();
                            CheckWinner();

                            break;
                    }
                }
                else
                {
                    switch (PlayerTurn)
                    {
                        case enPlayer.Player1:
                            PlayerTurn = enPlayer.Computer;
                            Btn.Image = Resources.X;
                            Btn.Tag = "X";
                            GameStatus.PlayCounter++;
                            lblTurn.Text = PlayerTurn.ToString();
                            CheckWinner();
                            break;

                        case enPlayer.Computer:

                            PlayerTurn = enPlayer.Player1;
                            Btn.Image = Resources.O;
                            Btn.Tag = "O";
                            GameStatus.PlayCounter++;
                            lblTurn.Text = PlayerTurn.ToString();
                            CheckWinner();

                            break;
                    }
                }

            }
            else
            {
                MessageBox.Show("You can't choose this !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        void ResetButton(Button Btn)
        {
            Btn.Tag = "?";
            Btn.Image = Resources.question_mark;
            Btn.BackColor = Color.Transparent;

        }
        void ResetGame()
        {

            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);
            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player1";
            lblWinner.Text = "In Progress";
            GameStatus.PlayCounter = 0;
            GameStatus.Winner = enWinner.enProgress;
            GameStatus.GameOver = false;



        }

        async void _ComputerMove()
        {
            Random random = new Random();
            Button[] AvailableButtons = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            List<Button> EmptyButtons = AvailableButtons.Where(btn => btn.Tag.ToString() == "?").ToList();

            if (EmptyButtons.Count > 0)
            {
                Button randomButton = EmptyButtons[random.Next(0, EmptyButtons.Count)];
                await Task.Delay(500);
                ChangeImage(randomButton);
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(int NumberOfMode)
        {
            InitializeComponent();
            if (NumberOfMode == 1)
            {
                Mode = enMode.vsFriend;
                lbl_Computer.Visible = false;
                lblComputer.Visible = false;
            }

            else
            {
                Mode = enMode.vsComputer;
                lblPlayer2.Visible = false;
                lbl_Player2.Visible = false;
            }
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Color colorOfColumns = Color.FromArgb(155, 127, 156);
            Pen pen = new Pen(colorOfColumns);
            pen.Color = colorOfColumns;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.Width = 10;

            e.Graphics.DrawLine(pen, 408, 110, 408, 460);
            e.Graphics.DrawLine(pen, 547, 110, 547, 460);

            e.Graphics.DrawLine(pen, 260, 220, 700, 220);
            e.Graphics.DrawLine(pen, 260, 344, 700, 344);
        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
