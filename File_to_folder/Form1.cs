namespace File_to_folder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = @"C:\carpeta";
        }      

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();

            if (DialogResult.OK == fb.ShowDialog()) textBox1.Text = fb.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(textBox1.Text);
            if (checkBox1.Checked == false) List_files_if_checkbox_false();
            else List_files_if_checkbox_true(d.FullName);
        }


        private void List_files_if_checkbox_false()
        {

            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(textBox1.Text);

            foreach (FileInfo f in d.GetFiles())
            {
                listBox1.Items.Add(f.FullName);
            }
        }
        int _c = 0;
        private void List_files_if_checkbox_true(string dir)
        {

            if (_c == 0)
            { foreach (string s in Directory.GetFiles(dir)) listBox1.Items.Add(s); }

            foreach (string s in Directory.GetDirectories(dir))
            {
                foreach (string s2 in Directory.GetFiles(s))
                {
                    listBox1.Items.Add(s2);
                }
                _c++;
                dir = s;
                List_files_if_checkbox_true(dir);
              //  MessageBox.Show(System.IO.Directory.GetParent(dir).FullName); ;
            }
            _c = 0;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {   
                foreach (string s in listBox1.Items)
                {
                    string namewithext = System.IO.Path.GetFileName(s);
                    string name = System.IO.Path.GetFileNameWithoutExtension(s);
                    string? folder = (System.IO.Path.GetDirectoryName(s));
                    System.IO.Directory.CreateDirectory(folder + @"\" + name);
                    System.IO.File.Move(s, folder + @"\" + name + @"\" + namewithext);

                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            int n = 0;
             foreach (string s in listBox1.Items)
                {
                    System.IO.File.Move(s, textBox1.Text + @"\" + System.IO.Path.GetFileName(s) + n.ToString());                    
                    n++;
                }

        }
    }
}