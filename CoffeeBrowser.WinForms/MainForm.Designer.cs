﻿using System.ComponentModel;

namespace CoffeeBrowser.WinForms;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
        blazorWebView = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
        SuspendLayout();
        // 
        // blazorWebView
        // 
        blazorWebView.Dock = DockStyle.Fill;
        blazorWebView.Location = new Point(0, 0);
        blazorWebView.Name = "blazorWebView";
        blazorWebView.Size = new Size(800, 450);
        blazorWebView.StartPath = "/";
        blazorWebView.TabIndex = 0;
        blazorWebView.Text = "blazorWebView";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(blazorWebView);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "MainForm";
        Text = "MainForm";
        ResumeLayout(false);
    }

    #endregion

    private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView blazorWebView;
}