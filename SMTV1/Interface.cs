using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using java.io;
using java.util;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.tagger.maxent;
using Console = System.Console;

namespace SMTV1
{
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {



        }

        private void button2_MouseHover(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void storeWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void convertionToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

        }

        private void banglaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b2EToolStripMenuItem.Text = "B2E";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            b2EToolStripMenuItem.Text = "E2B";
        }
        string[,] wordAnd_PosTag = new string[50, 50];
        string[] word;
        string[] POStag;
        private void TranslateButton1_Click(object sender, EventArgs e)
        {
            Destination_richTextBox1.Text = "";
            postAGGING_label3.Text = "";
            callMethod();
        }
        public void callMethod()
        {

            Destination_richTextBox1.Text = " ";
            var jarRoot = @"C:\Users\fahim\source\repos\WindowsFormsApp1\stanford-postagger-2017-06-09\stanford-postagger-2017-06-09";
            var modelsDirectory = jarRoot + @"\models";

            // Loading POS Tagger
            var tagger = new MaxentTagger(modelsDirectory + @"\english-bidirectional-distsim.tagger");

            // Text for tagging
            var text = Source_richTextBox2.Text;
            string[] words = text.Split(' ');
            word = new string[words.Length];
            POStag = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                String tagged = tagger.tagString(words[i]); //Initializing Tag for  word
                string[] word_PosTag_split = tagged.Split('_'); // Splitting Word and POS Tag

                word[i] = word_PosTag_split[0];              /// Assinging word to array
                POStag[i] = word_PosTag_split[1];           /// Assinging  POS Tag to array

            }

            int a = word.Length;
            Analysis_stg aAnalysis_Stg = new Analysis_stg();
            string sentence= aAnalysis_Stg.getSubject(word, POStag);
            Destination_richTextBox1.Text = sentence;

            //Console.WriteLine(wordAnd_PosTag[1,1]);

            //var sentences = MaxentTagger.tokenizeText(new StringReader(text)).toArray();
            //foreach (ArrayList sentence in sentences)
            //{

            //    var taggedSentence = tagger.tagSentence(sentence);
            //    postAGGING_label3.Text = SentenceUtils.listToString(taggedSentence, false);
            //    //Console.WriteLine(SentenceUtils.listToString(taggedSentence, false));

            //}
            this.ActiveControl = Source_richTextBox2;


        }

        private void Interface_Load(object sender, EventArgs e)
        {

        }
        //private void TranslateButton1_Click(object sender, EventArgs e)
        //{


        //}
    }
}
