// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;

        [SetUp]
        public void Test_Initialize()
        {
            stage = new Stage();
        }

        [Test]
        public void Test_Stage_Ctor()
        {
            Assert.AreEqual(0, stage.Performers.Count);
        }

        [Test]
        public void Test_Add_AddPerformer()
        {
            stage.AddPerformer(new Performer("Dido", "Radev", 29));
            stage.AddPerformer(new Performer("Someone", "Smith", 30));
            Assert.AreEqual(2, stage.Performers.Count);
        }

        [Test]
        public void Test_Add_AddPerformer_Invalid_Age()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(new Performer("Dido", "Radev", 10));
            });
        }

        [Test]
        public void Test_Add_AddPerformer_Invalid_Data()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddPerformer(null);
            });
        }

        [Test]
        public void Test_Add_AddSong_Invalid_Data()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSong(null);
            });
        }

        [Test]
        public void Test_Add_AddSong_Invalid_Duration()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSong(new Song("Mistify", new TimeSpan(0, 0, 30)));
            });
        }

        [Test]
        public void Test_Add_AddSongToPerformer_Invalid_Data()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSongToPerformer(null, "Dido");
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSongToPerformer("Test", null);
            });
        }

        [Test]
        public void Test_Add_GetPerformerAndSong_Invalid_Data()
        {
            stage.AddPerformer(new Performer("Dido", "Radev", 25));
            stage.AddSong(new Song("Mistify", new TimeSpan(0, 2, 30)));

            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer("Mistify", "Gosho");
            });
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer("Test", "Dido");
            });
        }

        [Test]
        public void Test_Add_AddSongToPerformer()
        {
            var performer = new Performer("Dido", "Radev", 25);
            stage.AddPerformer(performer);
            stage.AddSong(new Song("Mistify", new TimeSpan(0, 2, 30)));
            stage.AddSongToPerformer("Mistify", "Dido Radev");

            Assert.AreEqual(1, performer.SongList.Count);
            Assert.IsInstanceOf<string>(stage.AddSongToPerformer("Mistify", "Dido Radev"));
            Assert.AreEqual("Mistify (02:30) will be performed by Dido Radev", stage.AddSongToPerformer("Mistify", "Dido Radev"));
        }

        [Test]
        public void Test_Play()
        {
            var performer = new Performer("Dido", "Radev", 25);
            stage.AddPerformer(performer);
            stage.AddSong(new Song("Mistify", new TimeSpan(0, 2, 30)));
            stage.AddSongToPerformer("Mistify", "Dido Radev");

            Assert.IsInstanceOf<string>(stage.Play());
            Assert.AreEqual("1 performers played 1 songs", stage.Play());
        }
    }
}