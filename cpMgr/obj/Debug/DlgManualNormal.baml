   M S B A M L   `   `   `  ����@  <cpMgr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:cpMgrcpMgr  5   	   G CMyWpfControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:MyWpfControl;assembly=MyWpfControlMyWpfControl 5   	       cpMgr.DlgManualNormal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:cpMgr     5   	   IMyWpfControl0clr-namespace:MyWpfControl;assembly=MyWpfControl     5   	     � Title$  PORT#1-1��5	   	   $	��300��6   $	��276��6'    � WindowStartupLocation$ CenterOwner=�63   .��5
      �� -   5         ��Name$ cvsMain��5
      .+�5   
   �� $
��FLOT��6    �� Left$ 29��6   
 �� Top$ 25��60     MyWpfControl.StatusButton  5   
   -   5          Name$ 
btnFloatOn��5   $   $��ON��68   $ 87��6E   $ 25��6V   $��53��6f   $��26��6�      Brushs 5      ��	LightGray��6#   ��5      	LimeGreen��6#   5        5   
   -   5        $ btnFloatOff��5   $   $	��OFF��69   $	 145��6G   $ 25��6Y   $��53��6i   $��26��6�    5      ��	LightGray��6#   ��5      	LimeGreen��6#   5      �� 5   
   $��CEN'T��6   $ 29��6    $ 65��61     5   
   -   5        $ btnCenterOn��5   $   $��ON��69   $ 87��6F   $ 65��6W   $��53��6g   $��26��6�    5      ��	LightGray��6#   ��5      	LimeGreen��6#   5        5   
   -   5        $ btnCenterOff��5   $   $	��OFF��6:   $	 145��6H   $ 65��6Z   $��53��6j   $��26��6�    5!      ��	LightGray��6#   ��5"      	LimeGreen��6#   5$      �� 5%   
   $��
Charge
Bar��6   $ 29��6)   $ 97��6:     5&   
   -   5        $ btnChargeBarUp��5&   $   $��UP��6<   $ 87��6I   $	 105��6Z   $��53��6k   $��26��6�    5(      ��	LightGray��6#   ��5)      	LimeGreen��6#   5+        5,   
   -   5        $ btnChargeBarDown��5,   $   $
��DOWN��6>   $	 145��6M   $	 105��6_   $��53��6p   $��26��6�    5.      ��	LightGray��6#   ��5/      	LimeGreen��6#   51        MyWpfControl.StatusBorder  52   
   -   5          Name$ spLamp1��52   $      Text$  ��65   $��20��6>   $��20��6I   $ 40��6U   $	 166��6f   	   Brushs	 54      ��	LightGray��6#   ��55      	LimeGreen��6#   57      �� 58   
   $��	INPLACE 1��6   $ 65��6$   $	 162��65     59   
   -	   5        $ spLamp2��59   $   $  ��65   $��20��6>   $��20��6I   $ 40��6U   $	 192��6f   	 5;      ��	LightGray��6#   ��5<      	LimeGreen��6#   5>      �� 5?   
   $��	INPLACE 2��6   $ 65��6$   $	 188��65     5@   
   -
   5        $ spLamp3��5@   $   $  ��65   $��20��6>   $��20��6I   $ 40��6U   $	 218��6f   	 5B      ��	LightGray��6#   ��5C      	LimeGreen��6#   5E      �� 5F   
   $��DIAGONAL DETECT��6   $ 65��6*   $	 214��6;   5H      5I      