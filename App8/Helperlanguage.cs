using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;



namespace App8
{
    public class Helperlanguage
    {
        private string _ok;
        private string _cancel;
        private string _startGame;
        private string _setBet;
        private string _stand;
        private string _getCard;
        private string _doubleBet;
        private string _continue;
        private string _balance;
        private string _bet;
        private string _chooseLanguage;
        private string _textViewLang;
        private string _incorrectBet;
        public Helperlanguage(string language, Context context)
        {
               


             Android.Content.Res.Resources res = context.Resources;
           
            string recordTable = res.GetString(Resource.String.EnOk);
            if (language == "English")
            {
                _ok = res.GetString(Resource.String.EnOk);
                _cancel = res.GetString(Resource.String.EnCancel);
                _startGame = res.GetString(Resource.String.EnStartGame);
                _setBet = res.GetString(Resource.String.EnSetBet);
                _stand = res.GetString(Resource.String.EnStand);
                _getCard = res.GetString(Resource.String.EnGetCard);
                _doubleBet = res.GetString(Resource.String.EnDoubleBet);
                _continue = res.GetString(Resource.String.EnContinue);
                _balance = res.GetString(Resource.String.EnBalance);
                _bet = res.GetString(Resource.String.EnBet);
                _chooseLanguage = res.GetString(Resource.String.EnChooseLanguage);
                _textViewLang = res.GetString(Resource.String.EntextViewLang);
                _incorrectBet = res.GetString(Resource.String.EnIncorrectBet);
            }
                else if (language == "Russian")
            {
                _ok = res.GetString(Resource.String.RuOk);
                _cancel = res.GetString(Resource.String.RuCancel);
                _startGame = res.GetString(Resource.String.RuStartGame);
                _setBet = res.GetString(Resource.String.RuSetBet);
                _stand = res.GetString(Resource.String.RuStand);
                _getCard = res.GetString(Resource.String.RuGetCard);
                _doubleBet = res.GetString(Resource.String.RuDoubleBet);
                _continue = res.GetString(Resource.String.RuContinue);
                _balance = res.GetString(Resource.String.RuBalance);
                _bet = res.GetString(Resource.String.RuBet);
                _chooseLanguage = res.GetString(Resource.String.RuChooseLanguage);
                _textViewLang = res.GetString(Resource.String.RutextViewLang);
                _incorrectBet = res.GetString(Resource.String.RuIncorrectBet);
            }
            else
            {
                _ok = res.GetString(Resource.String.UkOk);
                _cancel = res.GetString(Resource.String.UkCancel);
                _startGame = res.GetString(Resource.String.UkStartGame);
                _setBet = res.GetString(Resource.String.UkSetBet);
                _stand = res.GetString(Resource.String.UkStand);
                _getCard = res.GetString(Resource.String.UkGetCard);
                _doubleBet = res.GetString(Resource.String.UkDoubleBet);
                _continue = res.GetString(Resource.String.UkContinue);
                _balance = res.GetString(Resource.String.UkBalance);
                _bet = res.GetString(Resource.String.UkBet);
                _chooseLanguage = res.GetString(Resource.String.UkChooseLanguage);
                _textViewLang = res.GetString(Resource.String.UktextViewLang);
                _incorrectBet = res.GetString(Resource.String.UkIncorrectBet);
            }
        }

    
        public string Ok
        {
            get
            {
                return _ok;
            }
        }
        public string Cancel
        {
            get
            {
                return _cancel;
            }
        }
        public string StartGame
        {
            get
            {
                return _startGame;
            }
        }
        public string SetBet
        {
            get
            {
                return _setBet;
            }
        }
        public string Stand
        {
            get
            {
                return _stand;
            }
        }
        public string GetCard
        {
            get
            {
                return _getCard;
            }
        }
        public string DoubleBet
        {
            get
            {
                return _doubleBet;
            }
        }
        public string Continue
        {
            get
            {
                return _continue;
            }
        }
        public string Balance
        {
            get
            {
                return _balance;
            }
        }
        public string Bet
        {
            get
            {
                return _bet;
            }
        }
        public string ChooseLanguage
        {
            get
            {
                return _chooseLanguage;
            }
        }
        public string TextViewLang
        {
            get
            {
                return _textViewLang;
            }
        }
        public string IncorrectBet
        {
            get
            {
                return _incorrectBet;
            }
        }


    }
}