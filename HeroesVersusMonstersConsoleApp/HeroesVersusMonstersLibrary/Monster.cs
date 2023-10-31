﻿using HeroesVersusMonstersLibrary.Abilities;
using HeroesVersusMonstersLibrary.Loots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVersusMonstersLibrary
{
    public class Monster : Entity
    {

        protected Ability _ability = new Ability();

        public Ability Ability
        {
            get { return _ability; }
            private set { _ability = value; }
        }




        //List made to contain all loots from the monster from the polymorph class "Generic Loot"

        protected Dictionary<GenericLoot, int> _lootTable = new Dictionary<GenericLoot, int>();

        public Dictionary<GenericLoot, int> LootTable
        {
            get { return _lootTable; }
            private set { _lootTable = value; }
        }

        //Value modifier to handle how much gold this mob is worth

        protected int _valueModifier;

		public int ValueModifier
		{
			get { return _valueModifier; }
			private set { _valueModifier = value; }
		}


        //Method to add an ability to the monster
        public void AddAbility(Ability ability)
        {
            this._ability = ability;
        }


        //Specifications related to monster type
        public Monster(int raceModifier)
        {
            switch (raceModifier)
            {
                case 0:
                    this._race = "Wolf";
                    this._name = "Wolf";
                    this._valueModifier = 1;
                    Pelt pelt = new Pelt(this);
                    GoldCoin gold = new GoldCoin();
                    _lootTable[pelt] = Dice.Roll(1, 4);
                    this.AddAbility(new Bite());
                    break;
                case 1:
                    this._race = "Orc";
                    this._name = "Orc";
                    this._strengthModifier += 1;
                    this._valueModifier = 2;
                    GoldCoin gold1 = new GoldCoin();
                    _lootTable[gold1] = Dice.Roll(1, 6) * this._valueModifier;
                    this.AddAbility(new Maul());
                    break;
                case 2:
                    this._race = "Dragonling";
                    this._name = "Dragonling";
                    this._staminaModifier += 1;
                    this._valueModifier = 3;
                    Pelt pelt2 = new Pelt(this);
                    GoldCoin gold2 = new GoldCoin();
                    _lootTable[pelt2] = Dice.Roll(1, 4);
                    _lootTable[gold2] = Dice.Roll(1, 6) * this._valueModifier;
                    this.AddAbility(new Fireball());
                    break;
            }

            this._healthPoints = (_stamina + _staminaModifier) * 10;
            this._maxHealthPoints = _healthPoints;

        }

    }
}
