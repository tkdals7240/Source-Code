﻿#pragma checksum "..\..\DlgBcrReadFail.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CFF60961EAD5E2CDC04A47DAF458B8B4429D06A978E5F6EEAB63A4305906E260"
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
    /// DlgBcrReadFail
    /// </summary>
    public partial class DlgBcrReadFail : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\DlgBcrReadFail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBCR1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\DlgBcrReadFail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBCR2;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\DlgBcrReadFail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnKeyIn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\DlgBcrReadFail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnComplete;
        
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
            System.Uri resourceLocater = new System.Uri("/cpMgr;component/dlgbcrreadfail.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DlgBcrReadFail.xaml"
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
            
            #line 10 "..\..\DlgBcrReadFail.xaml"
            ((cpMgr.DlgBcrReadFail)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 10 "..\..\DlgBcrReadFail.xaml"
            ((cpMgr.DlgBcrReadFail)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Window_IsVisibleChanged);
            
            #line default
            #line hidden
            
            #line 10 "..\..\DlgBcrReadFail.xaml"
            ((cpMgr.DlgBcrReadFail)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtBCR1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtBCR2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnKeyIn = ((MyWpfControl.StatusButton)(target));
            
            #line 16 "..\..\DlgBcrReadFail.xaml"
            this.btnKeyIn.Click += new System.Windows.RoutedEventHandler(this.btnKeyIn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnComplete = ((MyWpfControl.StatusButton)(target));
            
            #line 22 "..\..\DlgBcrReadFail.xaml"
            this.btnComplete.Click += new System.Windows.RoutedEventHandler(this.btnComplete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 28 "..\..\DlgBcrReadFail.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
