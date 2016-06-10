﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Control
{
    /// <summary>
    /// GButton.xaml에 대한 상호 작용 논리
    /// </summary>
    [GView("버튼")]
    public partial class GButton : GView
    {
        [GControl("내용")]
        public string Text
        {
            get
            {
                return ButtonContent.Content.ToString();
            }
            set
            {
                ButtonContent.Content = value;
            }
        }

        public GButton()
        {
            InitializeComponent();
        }
    }
}
