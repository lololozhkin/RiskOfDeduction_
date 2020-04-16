﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RiskOfDeduction.Domain;

namespace RiskOfDeduction.Drawing
{
    public class GameDrawer : IDrawer
    {
        private Game Game { get; set; }
        private HeroDrawer HeroDrawer { get; }
        private List<LevelDrawer> LevelDrawers { get; }

        public GameDrawer(Game game)
        {
            Game = game;
            HeroDrawer = new HeroDrawer(game.Player);
            LevelDrawers = game.Levels.Select(level => new LevelDrawer(level)).ToList();
        }

        public IEnumerable<IDrawable> GetDrawables()
        {
            return LevelDrawers[Game.CurrentLevelIndex].GetDrawables().Append(HeroDrawer);
        }
        
        public void UpdateDrawables()
        {
            foreach (var drawable in GetDrawables())
            {
                drawable.Update();
            }
        }
    }
}