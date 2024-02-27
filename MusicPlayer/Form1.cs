using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MusicPlayer
{
    public partial class MusicPlayer : Form
    {

        public MusicPlayer()
        {
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox1.InitialImage;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Music files|*.mp3;*.flac;*.wav";

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                axWindowsMediaPlayer1.URL = selectedFilePath;

                TagLib.File f = TagLib.File.Create(selectedFilePath);

                songNameLabel.Text = f.Tag.Title.ToString();
                if (f.Tag.Album != null | f.Tag.Year != null)
                {
                    var album = f.Tag.Album.ToString();
                    var year = f.Tag.Year.ToString();
                    albumNameLabel.Text = album + " - " + year;
                }

                else { albumNameLabel.Text = ""; }

                if (f.Tag.FirstAlbumArtist != null)
                {
                    artistNameLabel.Text = f.Tag.FirstAlbumArtist.ToString();
                }

                else { artistNameLabel.Text = ""; }

                if (f.Tag.Pictures != null && f.Tag.Pictures.Length != 0)
                {
                    var bin = (byte[])(f.Tag.Pictures[0].Data.Data);
                    pictureBox1.Image = Image.FromStream(new MemoryStream(bin));
                }
            }
        }

        private void MusicPlayer_Load(object sender, EventArgs e)
        {

        }
    }
}
