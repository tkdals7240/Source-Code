   M S B A M L   `   `   `  ����@  <cpMgr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:cpMgrcpMgr  5      G CMyWpfControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:MyWpfControl;assembly=MyWpfControlMyWpfControl 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6M       cpMgr.PageOperator   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:cpMgr     5      IMyWpfControl0clr-namespace:MyWpfControl;assembly=MyWpfControl     5      9System&clr-namespace:System;assembly=mscorlib     6M   -   5          N� Title$  OPERATOR��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��200 �6   .+�5   
   �� -   5         ��Name$ cvsMain��5      .+�5      �� -   5         ��Name$ txtRFID��5      $��
ABCDEFGHIJ��6%   $
��Left=�6:   $	��Top=�6U   $
��Bold"�6m    �� Left$	 245��6   
 �� Top$	 235��6�     MyWpfControl.ImageBorder  5      -   5          Name$ spRFID��5   '      Image$ Resources/RFID0.jpg��67   $
��Left=�6S   $��35��6n   $	��Top=�6z   $��73��6�   $	 245��6�   $	 200��6�      Images 5      ��Resources/RFID0.jpg��67   ��5      Resources/RFID1.jpg��67   5        5      -   5        $ spCST��5   '   $ Resources/CST_IN.png��66   $
��Left=�6S   $	��131��6n   $	��Top=�6{   $	��145��6�   $	 343��6�   $	 147��6�    5      ��Resources/CST_IN.png��68   ��5      Resources/CST_OUT.png��69   5        MyWpfControl.StatusBorder  5      -   5        	  Name$	 	spShuttle��5   (   
   Text$
 	SHUTTLE#1��6;   
�������$	 369��6c   $	 287��6u      Brushs 5!      ��	LightGray��6'   ��5"      Cyan��6"   5$      �� 5&      $��
Charge Bar��6   $
��Left=�6)   $	��Top=�6D   $	 245��6\   $	 385��6n     5'      -   5        $	 spChargeBar��5'   (   $

 None��6=   $��80��6I   
�������$	 347��6k   $	 391��6}    5)      ��	LightGray��6'   ��5*      	LimeGreen��6'   ��5+      Red��6!      Texts 5.      ��NONE��6*   ��5/      DOWN��6*   ��50      UP��6(   52      �� 53      $��Charger Status��6   $
��Left=�6-   $	��Top=�6H   $	 245��6`   $	 421��6r     54      -   5        $	 	spCharger��54   (   $	
 OFF��6;   $��80��6F   
�������$	 347��6h   $	 427��6z    56      ��	LightGray��6'   ��57      Red��6!    5:      ��OFF��6)   ��5;      ON��6(   5=      5>      �� 5?   
   $��1��6   .+�5@        -	   5        $	 chkAbnormal��5@   (   $
 NORMAL��6=   
�������
���2�2�$	��154��6u   $��30��6�   $��0,15,0,0q�6�    5B      ��	LimeGreen��6'   ��5C      Red��6!    5F      ��
NORMAL��6,   ��5G      ABNORMAL��6.   5I        5J      -
   5        $	 chkEmsStatus��5J   (   $
 
EMS NORMAL��6>   
�������
���2�2�$	��154��6z   $��30��6�   $��0,3,0,0q�6�    5L      ��	LimeGreen��6'   ��5M      Red��6!    5P      ��
EMS NORMAL��60   ��5Q      EMS OFF��6-   5S        5T      -   5        $	 chkAutoStatus��5T   (   $
 	AUTO STOP��6?   
�������
���  ��$	��154��6t   $��30��6�   $��0,3,0,0q�6�    5V      ��Red��6!   ��5W      	LimeGreen��6'    5Z      ��	AUTO STOP��6/   ��5[      
AUTO START��60   5]        5^      -   5        $	 chkOperModeStatus��5^   (   $
 -��6C   
�������
���2�2�$	��154��6v   $��30��6�   $��0,3,0,0q�6�    5`      ��	White��6#   ��5a      	LimeGreen��6'   ��5b      
Yellow��6$   ��5c      Red��6!    5f      ��-��6'   ��5g      	AUTO MODE��6/   ��5h      MANUAL MODE��61   ��5i      
TEACH MODE��60   5k      �� 5l      $��LIGHT CURTAIN��6   $��Center=�6,   $��0,20,0,5q�6I   
����  �$
��Bold"�6m     5m      -   5        $	 chkLightCurtain1��5m   (   $
 LIGHT CURTAIN #1��6B   
�������
���  ��$	��154��6~   $��30��6�   $��0,0,0,0q�6�    5o      ��Red��6!   ��5p      	LimeGreen��6'   5r        MyWpfControl.StatusButton  5s      -   5          Name$ btnModeChange��5s   (   $��MODE CHANGE
FORCE ON��6?   
�������$��53��6u   $	��154��6�   $
��Bold"�6�   $��0,50,0,0q�6�      Brushs 5u      ��	White��6#   ��5v      	LimeGreen��6'   5x      �� 5y       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   .+�5z        -   5        $ btnFWD��5z   ,   $	��FWD��6<   
�������$��53��6]   $��70��6i   $
��Bold"�6t   $��0,0,5,0q�6�    5|      ��	White��6'   ��5}      	LimeGreen��6+   5        5�      -   5        $ btnBWD��5�   ,   $	��BWD��6<   
�������$��53��6]   $��70��6i   $
��Bold"�6t   $��7,0,0,0q�6�    5�      ��	White��6'   ��5�      	LimeGreen��6+   5�      5�        5�      -   5        $ 
btnLightOn��5�   (   $��	LIGHT OFF��6<   
�������$��30��6c   $	��154��6o   $
��Bold"�6�   $��0,40,0,0q�6�    5�      ��	White��6#   ��5�      	LimeGreen��6'      Texts 5�      ��	LIGHT OFF��6/   ��5�      LIGHT ON��6.   5�      5�      5�      5�      