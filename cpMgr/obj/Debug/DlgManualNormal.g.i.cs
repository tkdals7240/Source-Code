﻿#pragma checksum "..\..\DlgManualNormal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "19BFA682E385D49844CD24321DAE3F2538492EB00797C257DAF2C143F704A8BB"
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
    /// DlgManualNormal
    /// </summary>
    public partial class DlgManualNormal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\DlgManualNormal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cvsMain;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\DlgManualNormal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnFloatOn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\DlgManualNormal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnFloatOff;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\DlgManualNormal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnCenterOn;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\DlgManualNormal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnCenterOff;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\DlgManualNormal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnChargeBarUp;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\DlgManualNormal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusButton btnChargeBarDown;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\DlgManualNormal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusBorder spLamp1;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\DlgManualNormal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusBorder spLamp2;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\DlgManualNormal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyWpfControl.StatusBorder spLamp3;
        
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
            System.Uri resourceLocater = new System.Uri("/cpMgr;component/dlgmanualnormal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DlgManualNormal.xaml"
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
            this.cvsMain = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.btnFloatOn = ((MyWpfControl.StatusButton)(target));
            
            #line 12 "..\..\DlgManualNormal.xaml"
            this.btnFloatOn.Click += new System.Windows.RoutedEventHandler(this.btnFloatOn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnFloatOff = ((MyWpfControl.StatusButton)(target));
            
            #line 18 "..\..\DlgManualNormal.xaml"
            this.btnFloatOff.Click += new System.Windows.RoutedEventHandler(this.btnFloatOff_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCenterOn = ((MyWpfControl.StatusButton)(target));
            
            #line 25 "..\..\DlgManualNormal.xaml"
            this.btnCenterOn.Click += new System.Windows.RoutedEventHandler(this.btnCenterOn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCenterOff = ((MyWpfControl.StatusButton)(target));
            
            #line 31 "..\..\DlgManualNormal.xaml"
            this.btnCenterOff.Click += new System.Windows.RoutedEventHandler(this.btnCenterOff_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnChargeBarUp = ((MyWpfControl.StatusButton)(target));
            
            #line 38 "..\..\DlgManualNormal.xaml"
            this.btnChargeBarUp.Click += new System.Windows.RoutedEventHandler(this.btnChargeBarUp_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnChargeBarDown = ((MyWpfControl.StatusButton)(target));
            
            #line 44 "..\..\DlgManualNormal.xaml"
            this.btnChargeBarDown.Click += new System.Windows.RoutedEventHandler(this.btnChargeBarDown_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.spLamp1 = ((MyWpfControl.StatusBorder)(target));
            return;
            case 9:
            this.spLamp2 = ((MyWpfControl.StatusBorder)(target));
            return;
            case 10:
            this.spLamp3 = ((MyWpfControl.StatusBorder)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
