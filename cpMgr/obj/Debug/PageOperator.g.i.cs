﻿#pragma checksum "..\..\PageOperator.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F22CFC5FDD75BE8221AA2A0E797DE1D567CA1DF90B31010839C64740B082CBE5"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using MyWpfControl;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using cpMgr;


namespace cpMgr {
    
    
    /// <summary>
    /// PageOperator
    /// </summary>
    public partial class PageOperator : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cvsMain;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtRFID;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.ImageBorder spRFID;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.ImageBorder spCST;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusBorder spShuttle;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusBorder spChargeBar;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusBorder spCharger;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusBorder chkAbnormal;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusBorder chkEmsStatus;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusBorder chkAutoStatus;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusBorder chkOperModeStatus;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusBorder chkLightCurtain1;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnModeChange;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnFWD;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnBWD;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\PageOperator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnLightOn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/cpMgr;component/pageoperator.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PageOperator.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\PageOperator.xaml"
            ((cpMgr.PageOperator)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            
            #line 10 "..\..\PageOperator.xaml"
            ((cpMgr.PageOperator)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Page_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cvsMain = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.txtRFID = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.spRFID = ((MyWpfControl.ImageBorder)(target));
            
            #line 19 "..\..\PageOperator.xaml"
            this.spRFID.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.spRFID_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.spCST = ((MyWpfControl.ImageBorder)(target));
            
            #line 25 "..\..\PageOperator.xaml"
            this.spCST.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.spCST_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.spShuttle = ((MyWpfControl.StatusBorder)(target));
            return;
            case 7:
            this.spChargeBar = ((MyWpfControl.StatusBorder)(target));
            
            #line 39 "..\..\PageOperator.xaml"
            this.spChargeBar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.spCST_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.spCharger = ((MyWpfControl.StatusBorder)(target));
            
            #line 52 "..\..\PageOperator.xaml"
            this.spCharger.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.spCharger_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.chkAbnormal = ((MyWpfControl.StatusBorder)(target));
            return;
            case 10:
            this.chkEmsStatus = ((MyWpfControl.StatusBorder)(target));
            return;
            case 11:
            this.chkAutoStatus = ((MyWpfControl.StatusBorder)(target));
            return;
            case 12:
            this.chkOperModeStatus = ((MyWpfControl.StatusBorder)(target));
            return;
            case 13:
            this.chkLightCurtain1 = ((MyWpfControl.StatusBorder)(target));
            return;
            case 14:
            this.btnModeChange = ((MyWpfControl.StatusButton)(target));
            
            #line 115 "..\..\PageOperator.xaml"
            this.btnModeChange.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnModeChange_MouseDown);
            
            #line default
            #line hidden
            
            #line 115 "..\..\PageOperator.xaml"
            this.btnModeChange.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.btnModeChange_MouseUp);
            
            #line default
            #line hidden
            return;
            case 15:
            this.btnFWD = ((MyWpfControl.StatusButton)(target));
            
            #line 122 "..\..\PageOperator.xaml"
            this.btnFWD.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnFWD_MouseDown);
            
            #line default
            #line hidden
            
            #line 122 "..\..\PageOperator.xaml"
            this.btnFWD.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.btnFWD_MouseUp);
            
            #line default
            #line hidden
            return;
            case 16:
            this.btnBWD = ((MyWpfControl.StatusButton)(target));
            
            #line 128 "..\..\PageOperator.xaml"
            this.btnBWD.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnBWD_MouseDown);
            
            #line default
            #line hidden
            
            #line 128 "..\..\PageOperator.xaml"
            this.btnBWD.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.btnBWD_MouseUp);
            
            #line default
            #line hidden
            return;
            case 17:
            this.btnLightOn = ((MyWpfControl.StatusButton)(target));
            
            #line 135 "..\..\PageOperator.xaml"
            this.btnLightOn.Click += new System.Windows.RoutedEventHandler(this.btnLightOn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

