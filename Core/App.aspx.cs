using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Core
{
    public partial class App : System.Web.UI.Page
    {
        private readonly string _blankImage = "img/blank.jpg";
        private readonly string _xImage = "img/X.png";
        private readonly string _oImage = "img/O.png";
        private readonly string _moveKey = "CurrentMove";

        private readonly Dictionary<int, ImageButton> buttonMap;

        protected void Page_Load(object sender,EventArgs e)
        {
            if (GameStatus.Value == "gamecompleted")
                initializeGame();
            foreach (Control imageButton in panel.Controls)
            {
                if (imageButton.GetType() == typeof(ImageButton))
                {
                    var imageButton1 = (ImageButton)imageButton;
                    buttonMap.Add(Convert.ToInt32(imageButton1.AlternateText), imageButton1);
                }
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (GameStatus.Value == "newgame")
            {
                initializeGame();
            }
        }

        private void initializeGame()
        {
            foreach (Control imageButton in panel.Controls)
            {
                if (imageButton.GetType() == typeof(ImageButton))
                {
                    ((ImageButton)imageButton).ImageUrl = _blankImage;
                    ((ImageButton)imageButton).Enabled = true;
                }
            }
            Session[_moveKey] = _xImage;
            GameStatus.Value = "newgame";
            GameResult.Text = "";
            NewGame.Visible = false;
            ViewState["clicks"] = 0;
        }

        protected void ResolveMoveEvent(object sender, ImageClickEventArgs e)
        {
            GameStatus.Value = "ongoing";
            ImageButton pressedButton = (ImageButton)sender;
            ViewState["clicks"] = (int)ViewState["clicks"] + 1;
            int buttonId = Convert.ToInt32(pressedButton.AlternateText);
            assignMoveImage(pressedButton);
            if(isGameComplete(buttonId))
            {
                disableButtons("Congrats! " + resolvePlayer() + " has won");
            }
            else if(isGameDraw())
            {
                disableButtons("Sorry! Game draw");
            }
            pressedButton.Enabled = false;
        }

        private void disableButtons(string gameResult)
        {
            foreach (Control imageButton in panel.Controls)
            {
                if (imageButton.GetType() == typeof(ImageButton))
                {
                    ((ImageButton)imageButton).Enabled = false;
                }
            }
            NewGame.Visible = true;
            GameResult.Text = gameResult;
            GameStatus.Value = "gamecompleted";
        }

        private bool isGameDraw()
        {
            return ((int)ViewState["clicks"]==9);
        }

        private string resolvePlayer()
        {
            if ((string)Session[_moveKey] == _xImage)
                return "Player 2";
            return "Player 1";
        }

        private bool isGameComplete(int buttonId)
        {
            int offset = buttonId % 3;
            if(checkDiagonals())
            {
                return true;
            }
            else if(offset == 0)
            {
                if (areEqual(buttonId, buttonId - 1) && areEqual(buttonId - 1, buttonId - 2))
                    return true;
                else if (areEqual(3, 6) && areEqual(6, 9))
                    return true;
            }
            else if(offset == 1)
            {
                if (areEqual(buttonId, buttonId + 1) && areEqual(buttonId + 1, buttonId + 2))
                    return true;
                else if (areEqual(1, 4) && areEqual(4, 7))
                    return true;
            }
            else if(offset == 2)
            {
                if (areEqual(2, 5) && areEqual(5, 8))
                    return true;
                else if (areEqual(4, 5) && areEqual(5, 6))
                    return true;
            }
            return false;
        }

        private bool checkDiagonals()
        {
            return
            (
                (areEqual(1, 5) && areEqual(5, 9)) || (areEqual(3, 5) && areEqual(5, 7))
            );
        }

        private bool areEqual(int bId1,int bId2)
        {
            return ((!isNull(bId1)) && (!isNull(bId2)) && (buttonMap[bId1].ImageUrl == buttonMap[bId2].ImageUrl));
        }

        private bool isNull(int buttonId)
        {
            return buttonMap[buttonId].ImageUrl == _blankImage;
        }


        private void assignMoveImage(ImageButton button)
        {
            button.ImageUrl = (string)Session[_moveKey];
            if ((string)Session[_moveKey] == _xImage)
                Session[_moveKey] = _oImage;
            else Session[_moveKey] = _xImage;
        }

        protected void NewGame_Click(object sender, EventArgs e)
        {
            initializeGame();
            NewGame.Visible = false;
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            initializeGame();
        }

        public App()
        {
            buttonMap = new Dictionary<int, ImageButton>();
        }
    }
}