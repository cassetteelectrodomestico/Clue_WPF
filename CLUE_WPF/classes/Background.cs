using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Clue_WPF.classes {
    class Background : Image {
        static readonly String[] resources = {
            "01_FrontYard", "02_House", "03_BackYard"
        };

        static readonly int[][,] coordinates = {
            new int [,] {
                { 213, 220},
                { 460, 222},
                { 490, 257},
                { 649, 256},
                { 705, 202},
                { 727, 194},
                { 752, 448},
                { 205, 447},
                { 213, 220}
            },

            new int [,] {
                {282, 498},
                {284, 84},
                {488, 85},
                {490, 131},
                {718, 137},
                {722, 256},
                {656, 260},
                {657, 285},
                {722, 284},
                {725, 372},
                {605, 375},
                {606, 538},
                {544, 539},
                {514, 500},
                {282, 498},

            },

            new int[,] {
                { 122, 457 },
                { 141, 94 },
                { 820, 96 },
                { 837, 458 },
                { 122, 457 },
            }
        };

        static ImageSource[] imageSources;

        public Background() {
            int x = 0;
            imageSources = new ImageSource[resources.Length];
            foreach (String s in resources) {
                imageSources[x] = (ImageSource)TryFindResource(s);
                x++;
            }
        }

        
    }
}
