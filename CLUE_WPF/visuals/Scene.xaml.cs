using Clue_WPF.classes;
using Clue_WPF.modelos;
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


        public static Character mainCharacter;

        public static bool canMove = true;

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

        public static MediaPlayer music;

        public static Uri[] songs = {
            new Uri(System.Environment.CurrentDirectory + "\\Soundtrack\\00_Her_Determination.mp3"),
            new Uri(System.Environment.CurrentDirectory + "\\Soundtrack\\01_Pizza_Parlor.mp3"),
            new Uri(System.Environment.CurrentDirectory + "\\Soundtrack\\02_Coffee_Shop.mp3"),
            new Uri(System.Environment.CurrentDirectory + "\\Soundtrack\\03_Forest_Maze.mp3"),
        };

        static List<Button>[] buttons = new List<Button>[3];

        static List<NPC>[] NPCs = new List<NPC>[2];
        static List<Weapon>[] weapons = new List<Weapon>[2];
        static List<Room>[] rooms = new List<Room>[2];

        public static TextInferior textInferior;

        public static Scene thisScene;

        public Scene() {
            InitializeComponent();
            thisScene = this;
            int x = 0;
            canMove = true;

            /*double[][][] cordenadasPersonas = {
                new double [][]{
                    new double []{ 280, 241 },
                    new double []{ 510, 253 },
                    new double []{ 696, 208 },
                    new double []{ 676, 296 },
                    new double []{ 626, 375 },
                    new double []{ 528, 496 },
                    new double []{ 458, 488 },
                },
                new double [][]{
                    new double []{ 214, 278 },
                    new double []{ 216, 453 },
                    new double []{ 737, 282 },
                    new double []{ 742, 453 },
                }
            };*/
            List<List<double[]>> puntosNPC = new List<List<double[]>>();
            List<double[]> a = new List<double[]>(), b = new List<double[]>();
            a.Add(new double[] { 280, 241 });
            a.Add(new double[] { 510, 253 });
            a.Add(new double[] { 696, 208 });
            a.Add(new double[] { 676, 296 });
            a.Add(new double[] { 626, 375 });
            a.Add(new double[] { 528, 496 });
            a.Add(new double[] { 458, 488 });
            puntosNPC.Add(a);
            b.Add(new double[] { 214, 278 });
            b.Add(new double[] { 216, 453 });
            b.Add(new double[] { 737, 282 });
            b.Add(new double[] { 742, 453 });
            puntosNPC.Add(b);

            List<List<double[]>> puntosWeapon = new List<List<double[]>>();
            puntosWeapon.Add(new List<double[]>());
            puntosWeapon[0].Add(new double[] { 513, 286});
            puntosWeapon[0].Add(new double[] { 643, 386 });
            puntosWeapon[0].Add(new double[] { 647, 415 });
            puntosWeapon[0].Add(new double[] { 664, 88 });
            puntosWeapon[0].Add(new double[] { 264, 77 });
            puntosWeapon[0].Add(new double[] { 264, 146 });
            puntosWeapon[0].Add(new double[] { 256, 320 });
            puntosWeapon.Add(new List<double[]>());
            puntosWeapon[1].Add(new double[] { 282, 185 });
            puntosWeapon[1].Add(new double[] { 350, 185 });
            puntosWeapon[1].Add(new double[] { 405, 185 });
            puntosWeapon[1].Add(new double[] { 530, 185 });
            puntosWeapon[1].Add(new double[] { 634, 185 });


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
                if (!canMove) return;
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
                if (!canMove) return;
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
                if (!canMove) return;
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
                if (!canMove) return;
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
            
            //music.Play();
            music.MediaEnded += (object sender, EventArgs e) => {
                music.Position = TimeSpan.Zero;
                music.Play();
            };
            

            mainCharacter = new Character(new string[] { "01_FL", "01_FR", "01_BL", "01_BR" }, startPoint[0][0]);
            

            mainPanel.Children.Add(canvas);

            MainWindow.WayPoints = Waypoints[0];
            this.mainScene.Source = imageSources[0];
            ThisScene = this;

            /*StackPanel sp = new StackPanel();
            sp.Children.Add(new Image() { Source = (ImageSource)TryFindResource("02_FR"), Height = 100 });

            canvas.Children.Add(sp);

            Canvas.SetLeft(sp, 100);
            Canvas.SetTop(sp, -100);

            sp.PreviewMouseUp += (object sender, MouseButtonEventArgs e) => {
                MessageBox.Show("Charcho");
            };*/

            NPCs[0] = new List<NPC>();
            NPCs[1] = new List<NPC>();

            String[] npcResources = { "02_FR", "03_FL", "04_FR", "05_FL" };

            for(int i = 1; i < 5; i++) {
                Random rnd = new Random();
                int place = rnd.Next(0, 2);
                int position = rnd.Next(0, puntosNPC[place].Count);
                double[] point = puntosNPC[place][position];

                NPC npc = new NPC(Juego.mainJuego.personajes[i], npcResources[i - 1], point);

                canvas.Children.Add(npc);

               

                Canvas.SetLeft(npc, point[0] - 10);
                Canvas.SetTop(npc, -(618 - point[1] + 80));

                puntosNPC[place].RemoveAt(position);

                npc.Visibility = Visibility.Hidden;

                NPCs[place].Add(npc);

            }

            weapons[0] = new List<Weapon>();
            weapons[1] = new List<Weapon>();

            String[] weaponResources = { "abrecartas", "cuchillo", "cuerda", "martillo", "sarten" };

            for (int i = 0; i < 5; i++) {
                Random rnd = new Random();
                int place = rnd.Next(0, 2);
                int position = rnd.Next(0, puntosWeapon[place].Count);

                double[] point = puntosWeapon[place][position];

                Weapon wpn = new Weapon(Juego.mainJuego.armas[i], weaponResources[i], point);

                canvas.Children.Add(wpn);

                

                Canvas.SetLeft(wpn, point[0] - 10);
                Canvas.SetTop(wpn, -(618 - point[1] + 80 - 50));

                puntosWeapon[place].RemoveAt(position);

                wpn.Visibility = Visibility.Hidden;

                weapons[place].Add(wpn);

            }

            rooms[0] = new List<Room>();
            rooms[1] = new List<Room>();

            double[][] roomPoints = {
                new double []{ 345, 406 },
                new double []{ 592, 406 },
                new double []{ 592, 180 },
                new double []{ 345, 180 },
                new double []{ 490, 289 }
            };

            for (int i = 0; i < 4; i++) {
                Room rm = new Room(Juego.mainJuego.lugares[i], roomPoints[i]);

                canvas.Children.Add(rm);


                Canvas.SetLeft(rm, roomPoints[i][0] - 10);
                Canvas.SetTop(rm, -(618 - roomPoints[i][1] + 80 - 60));

                rm.Visibility = Visibility.Hidden;

                rooms[0].Add(rm);

            }

            Room r = new Room(Juego.mainJuego.lugares[4], roomPoints[4]);

            canvas.Children.Add(r);


            Canvas.SetLeft(r, roomPoints[4][0] - 10);
            Canvas.SetTop(r, -(618 - roomPoints[4][1] + 80 - 60));

            r.Visibility = Visibility.Hidden;

            rooms[1].Add(r);






            canvas.Children.Add(mainCharacter);

            textInferior = new TextInferior();
            textInferior.title.Text = "Inicio";
            textInferior.description.Text = Juego.mainJuego.cinematicas[2].texto;
            canMove = false;
            textInferior.clickMethod = () => {
                canMove = true;
                textInferior.Visibility = Visibility.Hidden;
            };

            canvas.Children.Add(textInferior);
            Canvas.SetLeft(textInferior, 10);
            Canvas.SetTop(textInferior, -200);

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
                if (o > 0) foreach (NPC n in NPCs[o-1]) n.Visibility = Visibility.Hidden;
                if (d > 0) foreach (NPC n in NPCs[d-1]) n.Visibility = Visibility.Visible;

                if (o > 0) foreach (Weapon w in weapons[o - 1]) w.Visibility = Visibility.Hidden;
                if (d > 0) foreach (Weapon w in weapons[d - 1]) w.Visibility = Visibility.Visible;

                if (o > 0) foreach (Room r in rooms[o - 1]) r.Visibility = Visibility.Hidden;
                if (d > 0) foreach (Room r in rooms[d - 1]) r.Visibility = Visibility.Visible;
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
                Scene.canMove = true;
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
