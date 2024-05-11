namespace arduinoCubeSolver
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ptBoxCameraViewPort = new PictureBox();
            timerForWebCam = new System.Windows.Forms.Timer(components);
            btnAumentarDistancia = new Button();
            btnDisminuirDistancia = new Button();
            btnDecrementarTamaño = new Button();
            btnAumentarTamaño = new Button();
            label2 = new Label();
            btnStartSolving = new Button();
            btnScanCube = new Button();
            btnCalibrate = new Button();
            txtBoxSolution = new TextBox();
            label1 = new Label();
            labelNumMoves = new Label();
            labelIsSolved = new Label();
            comboBoxSelectedCamera = new ComboBox();
            label3 = new Label();
            cbListaCOM = new ComboBox();
            label4 = new Label();
            btnAbrir = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)ptBoxCameraViewPort).BeginInit();
            SuspendLayout();
            // 
            // ptBoxCameraViewPort
            // 
            ptBoxCameraViewPort.Location = new Point(12, 66);
            ptBoxCameraViewPort.Name = "ptBoxCameraViewPort";
            ptBoxCameraViewPort.Size = new Size(746, 489);
            ptBoxCameraViewPort.SizeMode = PictureBoxSizeMode.Zoom;
            ptBoxCameraViewPort.TabIndex = 0;
            ptBoxCameraViewPort.TabStop = false;
            // 
            // timerForWebCam
            // 
            timerForWebCam.Enabled = true;
            timerForWebCam.Interval = 33;
            timerForWebCam.Tick += timerForWebCam_Tick;
            // 
            // btnAumentarDistancia
            // 
            btnAumentarDistancia.Location = new Point(673, 13);
            btnAumentarDistancia.Name = "btnAumentarDistancia";
            btnAumentarDistancia.Size = new Size(39, 23);
            btnAumentarDistancia.TabIndex = 1;
            btnAumentarDistancia.Text = "+";
            btnAumentarDistancia.UseVisualStyleBackColor = true;
            btnAumentarDistancia.Click += btnAumentarDistancia_Click;
            // 
            // btnDisminuirDistancia
            // 
            btnDisminuirDistancia.Location = new Point(719, 13);
            btnDisminuirDistancia.Name = "btnDisminuirDistancia";
            btnDisminuirDistancia.Size = new Size(39, 23);
            btnDisminuirDistancia.TabIndex = 2;
            btnDisminuirDistancia.Text = "-";
            btnDisminuirDistancia.UseVisualStyleBackColor = true;
            btnDisminuirDistancia.Click += btnDisminuirDistancia_Click;
            // 
            // btnDecrementarTamaño
            // 
            btnDecrementarTamaño.Location = new Point(453, 13);
            btnDecrementarTamaño.Name = "btnDecrementarTamaño";
            btnDecrementarTamaño.Size = new Size(39, 23);
            btnDecrementarTamaño.TabIndex = 6;
            btnDecrementarTamaño.Text = "-";
            btnDecrementarTamaño.UseVisualStyleBackColor = true;
            btnDecrementarTamaño.Click += btnDecrementarTamaño_Click;
            // 
            // btnAumentarTamaño
            // 
            btnAumentarTamaño.Location = new Point(407, 13);
            btnAumentarTamaño.Name = "btnAumentarTamaño";
            btnAumentarTamaño.Size = new Size(39, 23);
            btnAumentarTamaño.TabIndex = 5;
            btnAumentarTamaño.Text = "+";
            btnAumentarTamaño.UseVisualStyleBackColor = true;
            btnAumentarTamaño.Click += btnAumentarTamaño_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(245, 17);
            label2.Name = "label2";
            label2.Size = new Size(141, 15);
            label2.TabIndex = 7;
            label2.Text = "Tamaño de los cuadrados";
            // 
            // btnStartSolving
            // 
            btnStartSolving.BackColor = Color.White;
            btnStartSolving.Enabled = false;
            btnStartSolving.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnStartSolving.FlatStyle = FlatStyle.Flat;
            btnStartSolving.Location = new Point(35, 641);
            btnStartSolving.Name = "btnStartSolving";
            btnStartSolving.Size = new Size(141, 34);
            btnStartSolving.TabIndex = 8;
            btnStartSolving.Text = "Comenzar a armar";
            btnStartSolving.UseVisualStyleBackColor = false;
            btnStartSolving.Click += btnStartSolving_Click;
            // 
            // btnScanCube
            // 
            btnScanCube.BackColor = Color.White;
            btnScanCube.Enabled = false;
            btnScanCube.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnScanCube.FlatStyle = FlatStyle.Flat;
            btnScanCube.Location = new Point(35, 601);
            btnScanCube.Name = "btnScanCube";
            btnScanCube.Size = new Size(141, 34);
            btnScanCube.TabIndex = 9;
            btnScanCube.Text = "Escanear cubo";
            btnScanCube.UseVisualStyleBackColor = false;
            btnScanCube.Click += btnScanCube_Click;
            // 
            // btnCalibrate
            // 
            btnCalibrate.BackColor = Color.White;
            btnCalibrate.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnCalibrate.FlatStyle = FlatStyle.Flat;
            btnCalibrate.Location = new Point(35, 561);
            btnCalibrate.Name = "btnCalibrate";
            btnCalibrate.Size = new Size(141, 34);
            btnCalibrate.TabIndex = 10;
            btnCalibrate.Text = "Calibrar camara";
            btnCalibrate.UseVisualStyleBackColor = false;
            btnCalibrate.Click += btnCalibrate_Click;
            // 
            // txtBoxSolution
            // 
            txtBoxSolution.Location = new Point(1121, 33);
            txtBoxSolution.Multiline = true;
            txtBoxSolution.Name = "txtBoxSolution";
            txtBoxSolution.ReadOnly = true;
            txtBoxSolution.Size = new Size(418, 65);
            txtBoxSolution.TabIndex = 11;
            txtBoxSolution.TextChanged += txtBoxSolution_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(511, 17);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 4;
            label1.Text = "Distancia del cubo";
            // 
            // labelNumMoves
            // 
            labelNumMoves.AutoSize = true;
            labelNumMoves.Location = new Point(1410, 25);
            labelNumMoves.Name = "labelNumMoves";
            labelNumMoves.Size = new Size(0, 15);
            labelNumMoves.TabIndex = 12;
            // 
            // labelIsSolved
            // 
            labelIsSolved.AutoSize = true;
            labelIsSolved.Location = new Point(1437, 66);
            labelIsSolved.Name = "labelIsSolved";
            labelIsSolved.Size = new Size(0, 15);
            labelIsSolved.TabIndex = 13;
            // 
            // comboBoxSelectedCamera
            // 
            comboBoxSelectedCamera.FormattingEnabled = true;
            comboBoxSelectedCamera.Location = new Point(66, 9);
            comboBoxSelectedCamera.Margin = new Padding(3, 2, 3, 2);
            comboBoxSelectedCamera.Name = "comboBoxSelectedCamera";
            comboBoxSelectedCamera.Size = new Size(140, 23);
            comboBoxSelectedCamera.TabIndex = 14;
            comboBoxSelectedCamera.SelectedIndexChanged += comboBoxSelectedCamera_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 11);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 15;
            label3.Text = "Camara";
            // 
            // cbListaCOM
            // 
            cbListaCOM.FormattingEnabled = true;
            cbListaCOM.Location = new Point(894, 58);
            cbListaCOM.Name = "cbListaCOM";
            cbListaCOM.Size = new Size(121, 23);
            cbListaCOM.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(824, 61);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 17;
            label4.Text = "Puerto:";
            // 
            // btnAbrir
            // 
            btnAbrir.BackColor = Color.White;
            btnAbrir.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnAbrir.FlatStyle = FlatStyle.Flat;
            btnAbrir.Location = new Point(182, 601);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(141, 34);
            btnAbrir.TabIndex = 18;
            btnAbrir.Text = "Sujetar";
            btnAbrir.UseVisualStyleBackColor = false;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.White;
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(182, 641);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(141, 34);
            btnCerrar.TabIndex = 19;
            btnCerrar.Text = "Soltar cubo";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1583, 705);
            Controls.Add(btnCerrar);
            Controls.Add(btnAbrir);
            Controls.Add(label4);
            Controls.Add(cbListaCOM);
            Controls.Add(label3);
            Controls.Add(comboBoxSelectedCamera);
            Controls.Add(labelIsSolved);
            Controls.Add(labelNumMoves);
            Controls.Add(txtBoxSolution);
            Controls.Add(btnCalibrate);
            Controls.Add(btnScanCube);
            Controls.Add(btnStartSolving);
            Controls.Add(label2);
            Controls.Add(btnDecrementarTamaño);
            Controls.Add(btnAumentarTamaño);
            Controls.Add(label1);
            Controls.Add(btnDisminuirDistancia);
            Controls.Add(btnAumentarDistancia);
            Controls.Add(ptBoxCameraViewPort);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "  ";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)ptBoxCameraViewPort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ptBoxCameraViewPort;
        private System.Windows.Forms.Timer timerForWebCam;
        private Button btnAumentarDistancia;
        private Button btnDisminuirDistancia;
        private Button btnDecrementarTamaño;
        private Button btnAumentarTamaño;
        private Label label2;
        private Button btnStartSolving;
        private Button btnScanCube;
        private Button btnCalibrate;
        private TextBox txtBoxSolution;
        private Label label1;
        private Label labelNumMoves;
        private Label labelIsSolved;
        private ComboBox comboBoxSelectedCamera;
        private Label label3;
        private ComboBox cbListaCOM;
        private Label label4;
        private Button btnAbrir;
        private Button btnCerrar;
    }
}