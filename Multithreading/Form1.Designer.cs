partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtRowsA;
    private TextBox txtColumnsA;
    private TextBox txtColumnsB;
    private TextBox txtThreads;
    private Button btnRun;
    private Label lblSequentialTime;
    private Label lblParallelTime;
    private Label lblThreadTime;
    private Label lblSpeedup;

    
    private TextBox txtResults;

    private void InitializeComponent()
    {
        txtThreads = new TextBox();
        btnRun = new Button();
        txtResults = new TextBox();
        label4 = new Label();
        SuspendLayout();
        // 
        // txtThreads
        // 
        txtThreads.Location = new Point(50, 50);
        txtThreads.Name = "txtThreads";
        txtThreads.Size = new Size(100, 27);
        txtThreads.TabIndex = 0;
        txtThreads.Text = "4";
        // 
        // btnRun
        // 
        btnRun.Location = new Point(180, 48);
        btnRun.Name = "btnRun";
        btnRun.Size = new Size(100, 32);
        btnRun.TabIndex = 1;
        btnRun.Text = "Wykonaj";
        btnRun.UseVisualStyleBackColor = true;
        btnRun.Click += btnRun_Click;
        // 
        // txtResults
        // 
        txtResults.Location = new Point(50, 100);
        txtResults.Multiline = true;
        txtResults.Name = "txtResults";
        txtResults.ReadOnly = true;
        txtResults.ScrollBars = ScrollBars.Vertical;
        txtResults.Size = new Size(600, 400);
        txtResults.TabIndex = 2;
        txtResults.TextChanged += txtResults_TextChanged;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(50, 20);
        label4.Name = "label4";
        label4.Size = new Size(94, 20);
        label4.TabIndex = 3;
        label4.Text = "Ilość wątków";
        // 
        // Form1
        // 
        ClientSize = new Size(700, 550);
        Controls.Add(label4);
        Controls.Add(txtResults);
        Controls.Add(btnRun);
        Controls.Add(txtThreads);
        Name = "Form1";
        Text = "Mnożenie Macierzy";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private Label label4;


    private Label label1;
    private Label label2;
    private Label label3;
    
}
