using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyGame
{
    class GameMusic
    {
        private MediaElement _GameMusic;
        private MediaElement _MenuMusic;
        private MediaElement _MenuMouseOverSound;

        public GameMusic()
        {
            _MenuMouseOverSound = new MediaElement()
            {
                LoadedBehavior = MediaState.Manual,
                UnloadedBehavior = MediaState.Manual
            };
            _GameMusic = new MediaElement()
            {
                LoadedBehavior = MediaState.Manual,
                UnloadedBehavior = MediaState.Manual
            };
            _MenuMusic = new MediaElement()
            {
                LoadedBehavior = MediaState.Manual,
                UnloadedBehavior = MediaState.Manual
            };
            _MenuMouseOverSound.Source = new Uri(Environment.CurrentDirectory + @"\Resources\Music\game_menu_select.wav");
            _GameMusic.Source = new Uri(Environment.CurrentDirectory + @"\Resources\Music\IlCostruttoreDiPonti.mp3");
            _MenuMusic.Source = new Uri(Environment.CurrentDirectory + @"\Resources\Music\MenuMusic.m4a");
        }

        public void Play(MusicType music)
        {
            switch (music)
            {
                case MusicType.GameMusic:
                    _GameMusic.Play();
                    break;
                case MusicType.MenuMusic:
                    _MenuMusic.Play();
                    break;
                case MusicType.MenuItemMusic:
                    _MenuMouseOverSound.Position = TimeSpan.FromSeconds(0);
                    _MenuMouseOverSound.Play();
                    break;
            }
        }

        public void Stop()
        {
            _GameMusic.Stop();
            _MenuMusic.Stop();
            _MenuMouseOverSound.Stop();
        }

        public void Stop(MusicType music)
        {
            switch (music)
            {
                case MusicType.GameMusic:
                    _GameMusic.Stop();
                    break;
                case MusicType.MenuMusic:
                    _MenuMusic.Stop();
                    break;
                case MusicType.MenuItemMusic:
                    _MenuMouseOverSound.Stop();
                    break;
            }
        }
    }
}
