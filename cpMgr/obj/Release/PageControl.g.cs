﻿#pragma checksum "..\..\PageControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6B2216BC91A03D6285639864EAB8ABC87B8A4FFBFD2E2F4C371E07C79BD1E799"
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
    /// PageControl
    /// </summary>
    public partial class PageControl : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\PageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMsg1;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\PageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnStatus;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\PageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnClose;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\PageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnDoorLock;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\PageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnLockOff;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\PageControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnLockOn;
        
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
            System.Uri resourceLocater = new System.Uri("/cpMgr;component/pagecontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PageControl.xaml"
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
            
            #line 10 "..\..\PageControl.xaml"
            ((cpMgr.PageControl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            
            #line 10 "..\..\PageControl.xaml"
            ((cpMgr.PageControl)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Page_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblMsg1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnStatus = ((MyWpfControl.StatusButton)(target));
            return;
            case 4:
            this.btnClose = ((MyWpfControl.StatusButton)(target));
            return;
            case 5:
            this.btnDoorLock = ((MyWpfControl.StatusButton)(target));
            return;
            case 6:
            this.btnLockOff = ((MyWpfControl.StatusButton)(target));
            
            #line 38 "..\..\PageControl.xaml"
            this.btnLockOff.Click += new System.Windows.RoutedEventHandler(this.btnLockOff_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnLockOn = ((MyWpfControl.StatusButton)(target));
            
            #line 44 "..\..\PageControl.xaml"
            this.btnLockOn.Click += new System.Windows.RoutedEventHandler(this.btnLockOn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
