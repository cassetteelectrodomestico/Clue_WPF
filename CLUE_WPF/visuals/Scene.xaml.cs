using Clue_WPF.classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clue_WPF.visuals {
    /// <summary>
    /// Lógica de interacción para Scene.xaml
    /// </summary>
    public partial class Scene : UserControl {


        private Character mainCharacter;

        public bool canMove = true;

        public double lastTime;

        public static Scene ThisScene;

        public object afterAnimation;

        static string[] resources = {
            "01_FrontYard", "02_House", "03_BackYard"
        };

        static double[][,] coordinates = {
            new double [,] {
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

            new double [,] {
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

            new double[,] {
                { 122, 457 },
                { 141, 94 },
                { 820, 96 },
                { 837, 458 },
                { 122, 457 },
            }
        };

        static double [][][] startPoint= {
            new double[][]{
                new double[] {480, 440},
                new double[] {379, 226}
            },
            new double[][] {
                new double[] {355, 490},
                new double[] {360, 93}
            },
            new double[][] {
                new double[] {355, 440}
            }
        };

        static ImageSource[] imageSources;

        static List<Side> [] Waypoints;

        static Canvas canvas;

        static MediaPlayer music;

        static Uri[] songs = {
            new Uri(System.Environment.CurrentDirectory + "\\Soundtrack\\00_Her_Determination.mp3"),
            new Uri(System.Environment.CurrentDirectory + "\\Soundtrack\\01_Pizza_Parlor.mp3"),
            new Uri(System.Environment.CurrentDirectory + "\\Soundtrack\\02_Coffee_Shop.mp3"),
            new Uri(System.Environment.CurrentDirectory + "\\Soundtrack\\03_Forest_Maze.mp3"),
        };

        static List<Button>[] buttons = new List<Button>[3];

        public Scene() {
            InitializeComponent();
            int x = 0;

            //LOAD RESOURCES

            imageSources = new ImageSource[resources.Length];
            foreach (string s in resources) {
                imageSources[x] = (ImageSource)TryFindResource(s);
                x++;
            }
            Waypoints = new List<Side>[coordinates.Length];

            for(int i = 0; i < coordinates.Length; i++) {
                Waypoints[i] = new List<Side>();
                int len = coordinates[i].GetLength(0);
                for (int j = 0; j < len - 1; j++) {
                    Waypoints[i].Add(new Side(
                        new CPoint(coordinates[i][j,0], coordinates[i][j,1]), new CPoint(coordinates[i][j + 1, 0], coordinates[i][j + 1, 1])
                    ));

                }
            }

            canvas = new Canvas();

            //ADD DOORS
            

            Button door = new Button() {Width = 80, Height = 115, Background = Brushes.Transparent, BorderBrush = Brushes.Transparent};
            Button frontDoor = new Button() { Width = 86, Height = 32, Background = Brushes.Transparent, BorderBrush = Brushes.Transparent, Visibility = Visibility.Hidden};
            Button backDoor = new Button() { Width = 86, Height = 32, Background = Brushes.Transparent, BorderBrush = Brushes.Transparent, Visibility = Visibility.Hidden };
            Button lastDoor = new Button() { Width = 86, Height = 32, Background = Brushes.Transparent, BorderBrush = Brushes.Transparent, Visibility = Visibility.Hidden };

            buttons[0] = new List<Button>();

            door.MouseEnter += ButtonMouseEnter;
            door.MouseLeave += ButtonMouseLeave;
            door.PreviewMouseUp += (object sender, MouseButtonEventArgs e) => {
                windowClick(e.GetPosition(this));
                canMove = false;
                Task.Delay(new TimeSpan(0, 0, 0, (int)(lastTime), 500)).ContinueWith(o => { changeScene(0, 1); });
            };
            canvas.Children.Add(door);
            Canvas.SetLeft(door, 343);
            Canvas.SetTop(door, -495);

            buttons[0].Add(door);
            buttons[1] = new List<Button>();

            frontDoor.MouseEnter += ButtonMouseEnter;
            frontDoor.MouseLeave += ButtonMouseLeave;
            frontDoor.PreviewMouseUp += (object sender, MouseButtonEventArgs e) => {
                windowClick(e.GetPosition(this));
                canMove = false;
                Task.Delay(new TimeSpan(0, 0, 0, (int)(lastTime), 500)).ContinueWith(o => { changeScene(1, 0); });
            };
            canvas.Children.Add(frontDoor);
            Canvas.SetLeft(frontDoor, 320);
            Canvas.SetTop(frontDoor, -100);

            buttons[1].Add(frontDoor);

            backDoor.MouseEnter += ButtonMouseEnter;
            backDoor.MouseLeave += ButtonMouseLeave;
            backDoor.PreviewMouseUp += (object sender, MouseButtonEventArgs e) => {
                windowClick(e.GetPosition(this));
                canMove = false;
                Task.Delay(new TimeSpan(0, 0, 0, (int)(lastTime), 500)).ContinueWith(o => { changeScene(1, 2); });
            };
            canvas.Children.Add(backDoor);
            Canvas.SetLeft(backDoor, 325);
            Canvas.SetTop(backDoor, -540);

            buttons[1].Add(backDoor);
            buttons[2] = new List<Button>();

            lastDoor.MouseEnter += ButtonMouseEnter;
            lastDoor.MouseLeave += ButtonMouseLeave;
            lastDoor.PreviewMouseUp += (object sender, MouseButtonEventArgs e) => {
                windowClick(e.GetPosition(this));
                canMove = false;
                Task.Delay(new TimeSpan(0, 0, 0, (int)(lastTime), 500)).ContinueWith(o => { changeScene(2, 1); });
            };
            canvas.Children.Add(lastDoor);
            Canvas.SetLeft(lastDoor, 310);
            Canvas.SetTop(lastDoor, -140);

            buttons[2].Add(lastDoor);

            music = new MediaPlayer();
            music.Open(songs[1]);
            
            music.Play();
            music.MediaEnded += (object sender, EventArgs e) => {
                music.Position = TimeSpan.Zero;
                music.Play();
            };
            

            mainCharacter = new Character(new string[] { "01_FL", "01_FR", "01_BL", "01_BR" }, startPoint[0][0]);
            canvas.Children.Add(mainCharacter);

            mainPanel.Children.Add(canvas);

            MainWindow.WayPoints = Waypoints[0];
            this.mainScene.Source = imageSources[0];
            ThisScene = this;
        }

        public void changeScene(int o, int d) {
            this.Dispatcher.Invoke(() => {
                double[] position = startPoint[d][((o == 2 && d == 1) || (o == 1 && d == 0)) ? 1 : 0];
                mainCharacter.X = position[0];
                mainCharacter.Y = position[1];
                MainWindow.WayPoints = Waypoints[d];
                this.mainScene.Source = imageSources[d];
                mainCharacter.reframe();
                mainCharacter.move(mainCharacter.X, mainCharacter.Y);
                music.Open(songs[d + 1]);
                music.Play();
                foreach(Button b in buttons[o]) {
                    b.Visibility = Visibility.Hidden;
                }
                foreach (Button b in buttons[d]) {
                    b.Visibility = Visibility.Visible;
                }
            });
        }

        public void windowClick(Point p) {
            if (!canMove) return;
            lastTime = mainCharacter.move(p.X, p.Y);
            canMove = false;
            Cursor = Cursors.Wait;
        }

        public static void WakeUp() {
            ThisScene.Dispatcher.Invoke(() => {
                ThisScene.Cursor = Cursors.Arrow;
                ThisScene.canMove = true;
            });
        }

        public void ButtonMouseEnter(object sender, MouseEventArgs e) {
            if(canMove) Cursor = Cursors.Hand;
        }

        public void ButtonMouseLeave(object sender, MouseEventArgs e) {
            if (canMove)  Cursor = Cursors.Arrow;
        }
    }
}
