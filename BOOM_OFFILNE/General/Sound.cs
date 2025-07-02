using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
namespace BOOM_OFFILNE.General
{
    public class Sound
    {    

        private static SoundPlayer startSound;
        private static SoundPlayer gameOverSound;
        private static SoundPlayer gameWinSound;
        private static SoundPlayer clickRoomSound;
        private static SoundPlayer Bummm;
        private static SoundPlayer eatItemsSound;
        private static WindowsMediaPlayer background = new WindowsMediaPlayer();
        private static string backgroundPath;
        public static void InitSound(String path)
        {
            Sound.startSound = new SoundPlayer(path + @"\Sound\amThanhGameStart.wav");
            Sound.gameOverSound = new SoundPlayer(path + @"\Sound\amThanhGameOver.wav");
            Sound.clickRoomSound = new SoundPlayer(path + @"\Sound\amThanhClick.wav");
            Sound.Bummm = new SoundPlayer(path + @"\Sound\amThanhNo.wav");
            Sound.eatItemsSound = new SoundPlayer(path + @"\Sound\amThanhAnVatPham.wav");
            Sound.backgroundPath = path + @"\Sound\amthanhbackground.wav";
        }

        public static void PlayBackgroundMusic()
        {
            if (background.playState != WMPPlayState.wmppsPlaying)
            {
                background.URL = backgroundPath;
                background.settings.setMode("loop", true);
                background.settings.volume = 20;
                background.controls.play();
            }

        }

        public static void StopBackgroundMusic()
        {
            background.controls.stop();
        }

        // phát âm thanh bắt đầu
        public static void PlayStartSound()
        {
            Sound.startSound.Play();
        }

        // dừng âm thanh bắt đầu
        public static void StopStartSound()
        {
            Sound.startSound.Play();
        }

       

        // phát âm thanh game over
        public static void PlayGameOverSound()
        {
            Sound.gameOverSound.Play();
        }

        // dừng âm thanh game over
        public static void StopGameOverSound()
        {
            Sound.gameOverSound.Play();
        }


        // phát âm thanh click
        public static void PlayClickRoomSound()
        {
            Sound.clickRoomSound.Play();
        }

        // dừng âm thanh click
        public static void StopClickRoomSound()
        {
            Sound.clickRoomSound.Play();
        }

        public static void PlayBummSound()
        {
            Sound.Bummm.Play();
        }

        public static void StopBummSound()
        {
            Sound.Bummm.Play();
        }

        // phát âm thanh ăn vật phẩm
        public static void PlayEatItemsSound()
        {
            Sound.eatItemsSound.Play();
        }

        // dừng âm thanh ăn vật phẩm
        public static void StopEatItemsSound()
        {
            Sound.eatItemsSound.Play();
        }

       

    }
}
