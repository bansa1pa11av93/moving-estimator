
namespace MovingEstimator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Move_description = new System.Windows.Forms.TextBox();
            this.Analyse_move = new System.Windows.Forms.Button();
            this.RTXTbox_Contrat = new System.Windows.Forms.RichTextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar3 = new System.Windows.Forms.MonthCalendar();
            this.lbl_Time1 = new System.Windows.Forms.Label();
            this.textBox1_time = new System.Windows.Forms.TextBox();
            this.lbl_Time2 = new System.Windows.Forms.Label();
            this.textBox2_time = new System.Windows.Forms.TextBox();
            this.textBox3_time = new System.Windows.Forms.TextBox();
            this.lbl_Time3 = new System.Windows.Forms.Label();
            this.checkBox1_lastavailability = new System.Windows.Forms.CheckBox();
            this.checkBox2_lastavailability = new System.Windows.Forms.CheckBox();
            this.checkBox3_lastavailability = new System.Windows.Forms.CheckBox();
            this.label_flexible_date = new System.Windows.Forms.Label();
            this.button_contract_eng = new System.Windows.Forms.Button();
            this.button_contract_fr = new System.Windows.Forms.Button();
            this.textBox_loadingTimeContract = new System.Windows.Forms.TextBox();
            this.textBox_UnloadingTimeContract = new System.Windows.Forms.TextBox();
            this.textBox_DriveTimeContract = new System.Windows.Forms.TextBox();
            this.textBox_InitialTimeContract = new System.Windows.Forms.TextBox();
            this.label_intial_displacement = new System.Windows.Forms.Label();
            this.label_driving_time = new System.Windows.Forms.Label();
            this.label_Loading_Time = new System.Windows.Forms.Label();
            this.label_unloading_time = new System.Windows.Forms.Label();
            this.label_2men = new System.Windows.Forms.Label();
            this.label_3men = new System.Windows.Forms.Label();
            this.label_4men = new System.Windows.Forms.Label();
            this.label_2men_loading_time = new System.Windows.Forms.Label();
            this.label_3men_loading_time = new System.Windows.Forms.Label();
            this.label_4men_loading_time = new System.Windows.Forms.Label();
            this.label_2men_unloading_time = new System.Windows.Forms.Label();
            this.label_3men_unloading_time = new System.Windows.Forms.Label();
            this.label_4men_unloading_time = new System.Windows.Forms.Label();
            this.checkBox_2men = new System.Windows.Forms.CheckBox();
            this.checkBox_3men = new System.Windows.Forms.CheckBox();
            this.checkBox_4men = new System.Windows.Forms.CheckBox();
            this.textBox_HourlyRate = new System.Windows.Forms.TextBox();
            this.label_HourlyRate = new System.Windows.Forms.Label();
            this.textBox_Distance = new System.Windows.Forms.TextBox();
            this.label_Distance = new System.Windows.Forms.Label();
            this.label_kmrate = new System.Windows.Forms.Label();
            this.textBox_kmRate = new System.Windows.Forms.TextBox();
            this.textBox_bagPrice = new System.Windows.Forms.TextBox();
            this.label_bagPrice = new System.Windows.Forms.Label();
            this.label_nb_of_trucks = new System.Windows.Forms.Label();
            this.button_reset = new System.Windows.Forms.Button();
            this.textBox_Starting_address = new System.Windows.Forms.TextBox();
            this.textBox_Destination_address = new System.Windows.Forms.TextBox();
            this.textBox_Starting_address_floor = new System.Windows.Forms.TextBox();
            this.textBox_Destination_address_floor = new System.Windows.Forms.TextBox();
            this.textBox_Destination_source = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Move_description
            // 
            this.Move_description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Move_description.Location = new System.Drawing.Point(12, 0);
            this.Move_description.Multiline = true;
            this.Move_description.Name = "Move_description";
            // this.Move_description.PlaceholderText = "Paste email text here...";
            this.Move_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Move_description.Size = new System.Drawing.Size(312, 258);
            this.Move_description.TabIndex = 60;
            this.Move_description.TextChanged += new System.EventHandler(this.Move_description_TextChanged);
            // 
            // Analyse_move
            // 
            this.Analyse_move.Location = new System.Drawing.Point(11, 264);
            this.Analyse_move.Name = "Analyse_move";
            this.Analyse_move.Size = new System.Drawing.Size(78, 29);
            this.Analyse_move.TabIndex = 2;
            this.Analyse_move.Text = "Analyse!";
            this.Analyse_move.UseVisualStyleBackColor = true;
            this.Analyse_move.Click += new System.EventHandler(this.button1_Click);
            // 
            // RTXTbox_Contrat
            // 
            this.RTXTbox_Contrat.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RTXTbox_Contrat.Location = new System.Drawing.Point(548, 340);
            this.RTXTbox_Contrat.Name = "RTXTbox_Contrat";
            this.RTXTbox_Contrat.Size = new System.Drawing.Size(555, 189);
            this.RTXTbox_Contrat.TabIndex = 4;
            this.RTXTbox_Contrat.Text = "";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(330, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 5;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(598, 0);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 6;
            this.monthCalendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateChanged);
            // 
            // monthCalendar3
            // 
            this.monthCalendar3.Location = new System.Drawing.Point(863, 0);
            this.monthCalendar3.Name = "monthCalendar3";
            this.monthCalendar3.TabIndex = 7;
            this.monthCalendar3.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar3_DateChanged);
            // 
            // lbl_Time1
            // 
            this.lbl_Time1.AutoSize = true;
            this.lbl_Time1.Location = new System.Drawing.Point(330, 211);
            this.lbl_Time1.Name = "lbl_Time1";
            this.lbl_Time1.Size = new System.Drawing.Size(54, 20);
            this.lbl_Time1.TabIndex = 8;
            this.lbl_Time1.Text = "Time 1";
            // 
            // textBox1_time
            // 
            this.textBox1_time.Location = new System.Drawing.Point(386, 210);
            this.textBox1_time.Name = "textBox1_time";
            this.textBox1_time.Size = new System.Drawing.Size(69, 27);
            this.textBox1_time.TabIndex = 9;
            // 
            // lbl_Time2
            // 
            this.lbl_Time2.AutoSize = true;
            this.lbl_Time2.Location = new System.Drawing.Point(598, 211);
            this.lbl_Time2.Name = "lbl_Time2";
            this.lbl_Time2.Size = new System.Drawing.Size(54, 20);
            this.lbl_Time2.TabIndex = 10;
            this.lbl_Time2.Text = "Time 2";
            // 
            // textBox2_time
            // 
            this.textBox2_time.Location = new System.Drawing.Point(654, 210);
            this.textBox2_time.Name = "textBox2_time";
            this.textBox2_time.Size = new System.Drawing.Size(74, 27);
            this.textBox2_time.TabIndex = 11;
            // 
            // textBox3_time
            // 
            this.textBox3_time.Location = new System.Drawing.Point(920, 210);
            this.textBox3_time.Name = "textBox3_time";
            this.textBox3_time.Size = new System.Drawing.Size(69, 27);
            this.textBox3_time.TabIndex = 12;
            // 
            // lbl_Time3
            // 
            this.lbl_Time3.AutoSize = true;
            this.lbl_Time3.Location = new System.Drawing.Point(863, 211);
            this.lbl_Time3.Name = "lbl_Time3";
            this.lbl_Time3.Size = new System.Drawing.Size(54, 20);
            this.lbl_Time3.TabIndex = 13;
            this.lbl_Time3.Text = "Time 3";
            // 
            // checkBox1_lastavailability
            // 
            this.checkBox1_lastavailability.AutoSize = true;
            this.checkBox1_lastavailability.Location = new System.Drawing.Point(458, 213);
            this.checkBox1_lastavailability.Name = "checkBox1_lastavailability";
            this.checkBox1_lastavailability.Size = new System.Drawing.Size(130, 24);
            this.checkBox1_lastavailability.TabIndex = 17;
            this.checkBox1_lastavailability.Text = "last availability";
            this.checkBox1_lastavailability.UseVisualStyleBackColor = true;
            // 
            // checkBox2_lastavailability
            // 
            this.checkBox2_lastavailability.AutoSize = true;
            this.checkBox2_lastavailability.Location = new System.Drawing.Point(730, 211);
            this.checkBox2_lastavailability.Name = "checkBox2_lastavailability";
            this.checkBox2_lastavailability.Size = new System.Drawing.Size(130, 24);
            this.checkBox2_lastavailability.TabIndex = 18;
            this.checkBox2_lastavailability.Text = "last availability";
            this.checkBox2_lastavailability.UseVisualStyleBackColor = true;
            // 
            // checkBox3_lastavailability
            // 
            this.checkBox3_lastavailability.AutoSize = true;
            this.checkBox3_lastavailability.Location = new System.Drawing.Point(991, 211);
            this.checkBox3_lastavailability.Name = "checkBox3_lastavailability";
            this.checkBox3_lastavailability.Size = new System.Drawing.Size(130, 24);
            this.checkBox3_lastavailability.TabIndex = 19;
            this.checkBox3_lastavailability.Text = "last availability";
            this.checkBox3_lastavailability.UseVisualStyleBackColor = true;
            // 
            // label_flexible_date
            // 
            this.label_flexible_date.Location = new System.Drawing.Point(179, 268);
            this.label_flexible_date.Name = "label_flexible_date";
            this.label_flexible_date.Size = new System.Drawing.Size(215, 23);
            this.label_flexible_date.TabIndex = 53;
            this.label_flexible_date.Text = "Flexible date ?";
            // 
            // button_contract_eng
            // 
            this.button_contract_eng.Location = new System.Drawing.Point(974, 252);
            this.button_contract_eng.Name = "button_contract_eng";
            this.button_contract_eng.Size = new System.Drawing.Size(116, 28);
            this.button_contract_eng.TabIndex = 22;
            this.button_contract_eng.Text = "Contract Eng";
            this.button_contract_eng.UseVisualStyleBackColor = true;
            this.button_contract_eng.Click += new System.EventHandler(this.button_contract_eng_Click);
            // 
            // button_contract_fr
            // 
            this.button_contract_fr.Location = new System.Drawing.Point(797, 252);
            this.button_contract_fr.Name = "button_contract_fr";
            this.button_contract_fr.Size = new System.Drawing.Size(116, 28);
            this.button_contract_fr.TabIndex = 23;
            this.button_contract_fr.Text = "Contrat FR";
            this.button_contract_fr.UseVisualStyleBackColor = true;
            this.button_contract_fr.Click += new System.EventHandler(this.button_contract_fr_Click);
            // 
            // textBox_loadingTimeContract
            // 
            this.textBox_loadingTimeContract.Location = new System.Drawing.Point(458, 277);
            this.textBox_loadingTimeContract.Name = "textBox_loadingTimeContract";
            this.textBox_loadingTimeContract.Size = new System.Drawing.Size(58, 27);
            this.textBox_loadingTimeContract.TabIndex = 24;
            this.textBox_loadingTimeContract.Text = "0";
            this.textBox_loadingTimeContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_UnloadingTimeContract
            // 
            this.textBox_UnloadingTimeContract.Location = new System.Drawing.Point(458, 311);
            this.textBox_UnloadingTimeContract.Name = "textBox_UnloadingTimeContract";
            this.textBox_UnloadingTimeContract.Size = new System.Drawing.Size(58, 27);
            this.textBox_UnloadingTimeContract.TabIndex = 25;
            this.textBox_UnloadingTimeContract.Text = "0";
            this.textBox_UnloadingTimeContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_DriveTimeContract
            // 
            this.textBox_DriveTimeContract.Location = new System.Drawing.Point(458, 377);
            this.textBox_DriveTimeContract.Name = "textBox_DriveTimeContract";
            this.textBox_DriveTimeContract.Size = new System.Drawing.Size(58, 27);
            this.textBox_DriveTimeContract.TabIndex = 26;
            this.textBox_DriveTimeContract.Text = "0";
            this.textBox_DriveTimeContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_InitialTimeContract
            // 
            this.textBox_InitialTimeContract.Location = new System.Drawing.Point(458, 344);
            this.textBox_InitialTimeContract.Name = "textBox_InitialTimeContract";
            this.textBox_InitialTimeContract.Size = new System.Drawing.Size(58, 27);
            this.textBox_InitialTimeContract.TabIndex = 27;
            this.textBox_InitialTimeContract.Text = "1";
            this.textBox_InitialTimeContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_intial_displacement
            // 
            this.label_intial_displacement.AutoSize = true;
            this.label_intial_displacement.Location = new System.Drawing.Point(372, 347);
            this.label_intial_displacement.Name = "label_intial_displacement";
            this.label_intial_displacement.Size = new System.Drawing.Size(80, 20);
            this.label_intial_displacement.TabIndex = 28;
            this.label_intial_displacement.Text = "Initial time";
            // 
            // label_driving_time
            // 
            this.label_driving_time.AutoSize = true;
            this.label_driving_time.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_driving_time.Location = new System.Drawing.Point(370, 380);
            this.label_driving_time.Name = "label_driving_time";
            this.label_driving_time.Size = new System.Drawing.Size(82, 20);
            this.label_driving_time.TabIndex = 29;
            this.label_driving_time.Text = "Route time";
            // 
            // label_Loading_Time
            // 
            this.label_Loading_Time.AutoSize = true;
            this.label_Loading_Time.Location = new System.Drawing.Point(355, 281);
            this.label_Loading_Time.Name = "label_Loading_Time";
            this.label_Loading_Time.Size = new System.Drawing.Size(97, 20);
            this.label_Loading_Time.TabIndex = 30;
            this.label_Loading_Time.Text = "Loading time";
            // 
            // label_unloading_time
            // 
            this.label_unloading_time.AutoSize = true;
            this.label_unloading_time.Location = new System.Drawing.Point(340, 314);
            this.label_unloading_time.Name = "label_unloading_time";
            this.label_unloading_time.Size = new System.Drawing.Size(112, 20);
            this.label_unloading_time.TabIndex = 31;
            this.label_unloading_time.Text = "Unloading time";
            // 
            // label_2men
            // 
            this.label_2men.AutoSize = true;
            this.label_2men.Location = new System.Drawing.Point(530, 249);
            this.label_2men.Name = "label_2men";
            this.label_2men.Size = new System.Drawing.Size(50, 20);
            this.label_2men.TabIndex = 32;
            this.label_2men.Text = "2 men";
            // 
            // label_3men
            // 
            this.label_3men.AutoSize = true;
            this.label_3men.Location = new System.Drawing.Point(608, 249);
            this.label_3men.Name = "label_3men";
            this.label_3men.Size = new System.Drawing.Size(50, 20);
            this.label_3men.TabIndex = 33;
            this.label_3men.Text = "3 men";
            // 
            // label_4men
            // 
            this.label_4men.AutoSize = true;
            this.label_4men.Location = new System.Drawing.Point(688, 249);
            this.label_4men.Name = "label_4men";
            this.label_4men.Size = new System.Drawing.Size(50, 20);
            this.label_4men.TabIndex = 34;
            this.label_4men.Text = "4 men";
            // 
            // label_2men_loading_time
            // 
            this.label_2men_loading_time.AutoSize = true;
            this.label_2men_loading_time.Location = new System.Drawing.Point(530, 280);
            this.label_2men_loading_time.Name = "label_2men_loading_time";
            this.label_2men_loading_time.Size = new System.Drawing.Size(17, 20);
            this.label_2men_loading_time.TabIndex = 35;
            this.label_2men_loading_time.Text = "0";
            // 
            // label_3men_loading_time
            // 
            this.label_3men_loading_time.AutoSize = true;
            this.label_3men_loading_time.Location = new System.Drawing.Point(608, 280);
            this.label_3men_loading_time.Name = "label_3men_loading_time";
            this.label_3men_loading_time.Size = new System.Drawing.Size(17, 20);
            this.label_3men_loading_time.TabIndex = 36;
            this.label_3men_loading_time.Text = "0";
            // 
            // label_4men_loading_time
            // 
            this.label_4men_loading_time.AutoSize = true;
            this.label_4men_loading_time.Location = new System.Drawing.Point(688, 280);
            this.label_4men_loading_time.Name = "label_4men_loading_time";
            this.label_4men_loading_time.Size = new System.Drawing.Size(17, 20);
            this.label_4men_loading_time.TabIndex = 37;
            this.label_4men_loading_time.Text = "0";
            // 
            // label_2men_unloading_time
            // 
            this.label_2men_unloading_time.AutoSize = true;
            this.label_2men_unloading_time.Location = new System.Drawing.Point(530, 313);
            this.label_2men_unloading_time.Name = "label_2men_unloading_time";
            this.label_2men_unloading_time.Size = new System.Drawing.Size(17, 20);
            this.label_2men_unloading_time.TabIndex = 38;
            this.label_2men_unloading_time.Text = "0";
            // 
            // label_3men_unloading_time
            // 
            this.label_3men_unloading_time.AutoSize = true;
            this.label_3men_unloading_time.Location = new System.Drawing.Point(608, 313);
            this.label_3men_unloading_time.Name = "label_3men_unloading_time";
            this.label_3men_unloading_time.Size = new System.Drawing.Size(17, 20);
            this.label_3men_unloading_time.TabIndex = 39;
            this.label_3men_unloading_time.Text = "0";
            // 
            // label_4men_unloading_time
            // 
            this.label_4men_unloading_time.AutoSize = true;
            this.label_4men_unloading_time.Location = new System.Drawing.Point(688, 313);
            this.label_4men_unloading_time.Name = "label_4men_unloading_time";
            this.label_4men_unloading_time.Size = new System.Drawing.Size(17, 20);
            this.label_4men_unloading_time.TabIndex = 40;
            this.label_4men_unloading_time.Text = "0";
            // 
            // checkBox_2men
            // 
            this.checkBox_2men.AutoSize = true;
            this.checkBox_2men.Location = new System.Drawing.Point(581, 252);
            this.checkBox_2men.Name = "checkBox_2men";
            this.checkBox_2men.Size = new System.Drawing.Size(18, 17);
            this.checkBox_2men.TabIndex = 41;
            this.checkBox_2men.UseVisualStyleBackColor = true;
            this.checkBox_2men.CheckedChanged += new System.EventHandler(this.checkBox_2men_CheckedChanged);
            // 
            // checkBox_3men
            // 
            this.checkBox_3men.AutoSize = true;
            this.checkBox_3men.Location = new System.Drawing.Point(657, 252);
            this.checkBox_3men.Name = "checkBox_3men";
            this.checkBox_3men.Size = new System.Drawing.Size(18, 17);
            this.checkBox_3men.TabIndex = 42;
            this.checkBox_3men.UseVisualStyleBackColor = true;
            this.checkBox_3men.CheckedChanged += new System.EventHandler(this.checkBox_3men_CheckedChanged);
            // 
            // checkBox_4men
            // 
            this.checkBox_4men.AutoSize = true;
            this.checkBox_4men.Location = new System.Drawing.Point(737, 252);
            this.checkBox_4men.Name = "checkBox_4men";
            this.checkBox_4men.Size = new System.Drawing.Size(18, 17);
            this.checkBox_4men.TabIndex = 43;
            this.checkBox_4men.UseVisualStyleBackColor = true;
            this.checkBox_4men.CheckedChanged += new System.EventHandler(this.checkBox_4men_CheckedChanged);
            // 
            // textBox_HourlyRate
            // 
            this.textBox_HourlyRate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox_HourlyRate.Location = new System.Drawing.Point(424, 460);
            this.textBox_HourlyRate.Name = "textBox_HourlyRate";
            this.textBox_HourlyRate.Size = new System.Drawing.Size(92, 39);
            this.textBox_HourlyRate.TabIndex = 45;
            this.textBox_HourlyRate.Text = "0";
            this.textBox_HourlyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_HourlyRate
            // 
            this.label_HourlyRate.AutoSize = true;
            this.label_HourlyRate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_HourlyRate.Location = new System.Drawing.Point(313, 467);
            this.label_HourlyRate.Name = "label_HourlyRate";
            this.label_HourlyRate.Size = new System.Drawing.Size(105, 32);
            this.label_HourlyRate.TabIndex = 46;
            this.label_HourlyRate.Text = "rate $/h";
            // 
            // textBox_Distance
            // 
            this.textBox_Distance.Location = new System.Drawing.Point(458, 410);
            this.textBox_Distance.Name = "textBox_Distance";
            this.textBox_Distance.Size = new System.Drawing.Size(58, 27);
            this.textBox_Distance.TabIndex = 47;
            this.textBox_Distance.Text = "0";
            this.textBox_Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Distance
            // 
            this.label_Distance.AutoSize = true;
            this.label_Distance.Location = new System.Drawing.Point(386, 413);
            this.label_Distance.Name = "label_Distance";
            this.label_Distance.Size = new System.Drawing.Size(66, 20);
            this.label_Distance.TabIndex = 48;
            this.label_Distance.Text = "Distance";
            // 
            // label_kmrate
            // 
            this.label_kmrate.AutoSize = true;
            this.label_kmrate.Location = new System.Drawing.Point(832, 300);
            this.label_kmrate.Name = "label_kmrate";
            this.label_kmrate.Size = new System.Drawing.Size(43, 20);
            this.label_kmrate.TabIndex = 49;
            this.label_kmrate.Text = "$/km";
            // 
            // textBox_kmRate
            // 
            this.textBox_kmRate.Location = new System.Drawing.Point(881, 297);
            this.textBox_kmRate.Name = "textBox_kmRate";
            this.textBox_kmRate.Size = new System.Drawing.Size(58, 27);
            this.textBox_kmRate.TabIndex = 50;
            this.textBox_kmRate.Text = "0,89";
            this.textBox_kmRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_bagPrice
            // 
            this.textBox_bagPrice.Location = new System.Drawing.Point(1032, 299);
            this.textBox_bagPrice.Name = "textBox_bagPrice";
            this.textBox_bagPrice.Size = new System.Drawing.Size(58, 27);
            this.textBox_bagPrice.TabIndex = 51;
            this.textBox_bagPrice.Text = "0";
            this.textBox_bagPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_bagPrice
            // 
            this.label_bagPrice.AutoSize = true;
            this.label_bagPrice.Location = new System.Drawing.Point(955, 299);
            this.label_bagPrice.Name = "label_bagPrice";
            this.label_bagPrice.Size = new System.Drawing.Size(71, 20);
            this.label_bagPrice.TabIndex = 52;
            this.label_bagPrice.Text = "Bag Price";
            // 
            // label_nb_of_trucks
            // 
            this.label_nb_of_trucks.Location = new System.Drawing.Point(12, 428);
            this.label_nb_of_trucks.Name = "label_nb_of_trucks";
            this.label_nb_of_trucks.Size = new System.Drawing.Size(444, 22);
            this.label_nb_of_trucks.TabIndex = 44;
            this.label_nb_of_trucks.Text = " estimated volume, % of loading and nb of trucks";
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(95, 264);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(78, 29);
            this.button_reset.TabIndex = 54;
            this.button_reset.Text = "Reset!";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // textBox_Starting_address
            // 
            this.textBox_Starting_address.Location = new System.Drawing.Point(12, 299);
            this.textBox_Starting_address.Name = "textBox_Starting_address";
            this.textBox_Starting_address.Size = new System.Drawing.Size(316, 27);
            this.textBox_Starting_address.TabIndex = 55;
            this.textBox_Starting_address.Text = "staring address";
            // 
            // textBox_Destination_address
            // 
            this.textBox_Destination_address.Location = new System.Drawing.Point(12, 365);
            this.textBox_Destination_address.Name = "textBox_Destination_address";
            this.textBox_Destination_address.Size = new System.Drawing.Size(316, 27);
            this.textBox_Destination_address.TabIndex = 56;
            this.textBox_Destination_address.Text = "destination address";
            // 
            // textBox_Starting_address_floor
            // 
            this.textBox_Starting_address_floor.Location = new System.Drawing.Point(113, 332);
            this.textBox_Starting_address_floor.Name = "textBox_Starting_address_floor";
            this.textBox_Starting_address_floor.Size = new System.Drawing.Size(215, 27);
            this.textBox_Starting_address_floor.TabIndex = 57;
            this.textBox_Starting_address_floor.Text = "staring address floor";
            this.textBox_Starting_address_floor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_Destination_address_floor
            // 
            this.textBox_Destination_address_floor.Location = new System.Drawing.Point(113, 398);
            this.textBox_Destination_address_floor.Name = "textBox_Destination_address_floor";
            this.textBox_Destination_address_floor.Size = new System.Drawing.Size(215, 27);
            this.textBox_Destination_address_floor.TabIndex = 58;
            this.textBox_Destination_address_floor.Text = "destination address floor";
            this.textBox_Destination_address_floor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_Destination_source
            // 
            this.textBox_Destination_source.Location = new System.Drawing.Point(30, 464);
            this.textBox_Destination_source.Name = "textBox_Destination_source";
            this.textBox_Destination_source.Size = new System.Drawing.Size(241, 27);
            this.textBox_Destination_source.TabIndex = 59;
            this.textBox_Destination_source.Text = "Source";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 541);
            this.Controls.Add(this.textBox_Destination_source);
            this.Controls.Add(this.textBox_Destination_address_floor);
            this.Controls.Add(this.textBox_Starting_address_floor);
            this.Controls.Add(this.textBox_Destination_address);
            this.Controls.Add(this.textBox_Starting_address);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.label_bagPrice);
            this.Controls.Add(this.textBox_bagPrice);
            this.Controls.Add(this.textBox_kmRate);
            this.Controls.Add(this.label_kmrate);
            this.Controls.Add(this.label_Distance);
            this.Controls.Add(this.textBox_Distance);
            this.Controls.Add(this.label_HourlyRate);
            this.Controls.Add(this.textBox_HourlyRate);
            this.Controls.Add(this.label_nb_of_trucks);
            this.Controls.Add(this.checkBox_4men);
            this.Controls.Add(this.checkBox_3men);
            this.Controls.Add(this.checkBox_2men);
            this.Controls.Add(this.label_4men_unloading_time);
            this.Controls.Add(this.label_3men_unloading_time);
            this.Controls.Add(this.label_2men_unloading_time);
            this.Controls.Add(this.label_4men_loading_time);
            this.Controls.Add(this.label_3men_loading_time);
            this.Controls.Add(this.label_2men_loading_time);
            this.Controls.Add(this.label_4men);
            this.Controls.Add(this.label_3men);
            this.Controls.Add(this.label_2men);
            this.Controls.Add(this.label_unloading_time);
            this.Controls.Add(this.label_Loading_Time);
            this.Controls.Add(this.label_driving_time);
            this.Controls.Add(this.label_intial_displacement);
            this.Controls.Add(this.textBox_InitialTimeContract);
            this.Controls.Add(this.textBox_DriveTimeContract);
            this.Controls.Add(this.textBox_UnloadingTimeContract);
            this.Controls.Add(this.textBox_loadingTimeContract);
            this.Controls.Add(this.button_contract_fr);
            this.Controls.Add(this.button_contract_eng);
            this.Controls.Add(this.label_flexible_date);
            this.Controls.Add(this.checkBox3_lastavailability);
            this.Controls.Add(this.checkBox2_lastavailability);
            this.Controls.Add(this.checkBox1_lastavailability);
            this.Controls.Add(this.lbl_Time3);
            this.Controls.Add(this.textBox3_time);
            this.Controls.Add(this.textBox2_time);
            this.Controls.Add(this.lbl_Time2);
            this.Controls.Add(this.textBox1_time);
            this.Controls.Add(this.lbl_Time1);
            this.Controls.Add(this.monthCalendar3);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.RTXTbox_Contrat);
            this.Controls.Add(this.Analyse_move);
            this.Controls.Add(this.Move_description);
            this.Name = "Form1";
            this.Text = "EStimateur déménagement";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox Move_description;
        private System.Windows.Forms.Button Analyse_move;
        private System.Windows.Forms.RichTextBox RTXTbox_Contrat;

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.MonthCalendar monthCalendar3;
        private System.Windows.Forms.Label lbl_Time1;
        private System.Windows.Forms.TextBox textBox1_time;
        private System.Windows.Forms.Label lbl_Time2;
        private System.Windows.Forms.TextBox textBox2_time;
        private System.Windows.Forms.TextBox textBox3_time;
        private System.Windows.Forms.Label lbl_Time3;
        private System.Windows.Forms.CheckBox checkBox1_lastavailability;
        private System.Windows.Forms.CheckBox checkBox2_lastavailability;
        private System.Windows.Forms.CheckBox checkBox3_lastavailability;
        private System.Windows.Forms.Label label_flexible_date;
        private System.Windows.Forms.Button button_contract_eng;
        private System.Windows.Forms.Button button_contract_fr;
        private System.Windows.Forms.TextBox textBox_loadingTimeContract;
        private System.Windows.Forms.TextBox textBox_UnloadingTimeContract;
        private System.Windows.Forms.TextBox textBox_DriveTimeContract;
        private System.Windows.Forms.TextBox textBox_InitialTimeContract;
        private System.Windows.Forms.Label label_intial_displacement;
        private System.Windows.Forms.Label label_driving_time;
        private System.Windows.Forms.Label label_Loading_Time;
        private System.Windows.Forms.Label label_unloading_time;
        private System.Windows.Forms.Label label_2men;
        private System.Windows.Forms.Label label_3men;
        private System.Windows.Forms.Label label_4men;
        private System.Windows.Forms.Label label_2men_loading_time;
        private System.Windows.Forms.Label label_3men_loading_time;
        private System.Windows.Forms.Label label_4men_loading_time;
        private System.Windows.Forms.Label label_2men_unloading_time;
        private System.Windows.Forms.Label label_3men_unloading_time;
        private System.Windows.Forms.Label label_4men_unloading_time;
        private System.Windows.Forms.CheckBox checkBox_2men;
        private System.Windows.Forms.CheckBox checkBox_3men;
        private System.Windows.Forms.CheckBox checkBox_4men;
        private System.Windows.Forms.TextBox textBox_HourlyRate;
        private System.Windows.Forms.Label label_HourlyRate;
        private System.Windows.Forms.TextBox textBox_Distance;
        private System.Windows.Forms.Label label_Distance;
        private System.Windows.Forms.Label label_kmrate;
        private System.Windows.Forms.TextBox textBox_kmRate;
        private System.Windows.Forms.TextBox textBox_bagPrice;
        private System.Windows.Forms.Label label_bagPrice;
        private System.Windows.Forms.Label label_nb_of_trucks;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.TextBox textBox_Starting_address;
        private System.Windows.Forms.TextBox textBox_Destination_address;
        private System.Windows.Forms.TextBox textBox_Starting_address_floor;
        private System.Windows.Forms.TextBox textBox_Destination_address_floor;
        private System.Windows.Forms.TextBox textBox_Destination_source;
    }
}

