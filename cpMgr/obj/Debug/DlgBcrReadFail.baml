   M S B A M L   `   `   `  ����@  <cpMgr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:cpMgrcpMgr  5   	   G CMyWpfControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:MyWpfControl;assembly=MyWpfControlMyWpfControl 5   	       cpMgr.DlgBcrReadFail   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:cpMgr     5   	   IMyWpfControl0clr-namespace:MyWpfControl;assembly=MyWpfControl     5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStyle$ SingleBorderWindow=�6    � WindowStartupLocation$ CenterOwner=�6@    � Topmost . $y�Hidden=�6s    � Title$&  PORT 1-1 CST BCR READING FAILED.��5
   	   $	��198��62   $	��296��6?   .��5      �� .+�5   
   �� $��	P1-1 DATA��6    �� Left$ 34��6$   
 �� Top$ 24��65   �� 5   
   -   5         ��Name$ txtBCR1��5      $��20��6#   $	 116��6/   $��
ABCDEFGHIJ��6A    �� 
IsReadOnly . $ 28��6e   $	��120��6u   �� 5   
   $��
INPUT DATA��6   $ 34��6%   $ 60��66   �� 5   
   -   5        $ txtBCR2��5      $��20��6#   $	 116��6/   $��
ABCDEFGHIJ��6A    . $ 64��6e   $	��120��6u     MyWpfControl.StatusButton  5   
   -   5        	  Name$	 btnKeyIn��5   $   $��KEY IN��66   $ 40��6G   $	 123��6X   $��60��6i   
   Brushs
 5      ��	LightGray��6#   ��5      	LimeGreen��6#   5        5   
   -   5        $	 btnComplete��5   $   $��Complete��69   $	 107��6L   $	 123��6^   $��60��6o   
 5      ��	LightGray��6#   ��5      	LimeGreen��6#   5      �� 5   
   -   5        $��Close��5      $	 176��6!   $	 123��63   $��60��6D   6O   5      5      