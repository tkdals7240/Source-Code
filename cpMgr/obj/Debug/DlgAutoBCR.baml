   M S B A M L   `   `   `  ����@  <cpMgr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:cpMgrcpMgr  5   	   G CMyWpfControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:MyWpfControl;assembly=MyWpfControlMyWpfControl 5   	       cpMgr.DlgAutoBCR   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:cpMgr     5   	   IMyWpfControl0clr-namespace:MyWpfControl;assembly=MyWpfControl     5   	     � 
ResizeMode$  NoResize=�5	   	    � WindowStyle$ SingleBorderWindow=�6    � WindowStartupLocation$ CenterOwner=�6@    � Topmost .  � Title$ AutoBCR��5
   	   $	��282��6   $	��293��6&   .��5      �� .+�5   
   �� $��CST ID��6    �� Left$ 34��6!   
 �� Top$ 24��62   �� 5   
   -   5         ��Name$ txtCstID��5      $��20��6$   $	 116��60   $��
ABCDEFGHIJ��6B   $ 28��6T   $	��120��6d   �� 5   
   $��OK COUNT��6   $ 34��6#   $ 64��64   �� 5   
   -   5        $ 
txtCountOK��5      $��20��6&   $	 174��62    �� TextAlignment$ Right=�6D   $��12345��6Z   $ 68��6g   $��62��6w   �� 5   
   -   5        $��Reset��5      $	 116��6!   $ 68��63   $��53��6C   6N   �� 5   
   $��NG COUNT��6   $ 34��6#   $	 104��64   �� 5   
   -   5        $ 
txtCountNG��5      $��20��6&   $	 174��62   $ Right=�6D   $��12345��6Z   $	 108��6g   $��62��6x   �� 5   
   -   5        $��Reset��5      $	 116��6!   $	 108��63   $��53��6D   6O   �� 5   
   -   5        $��TIGER��5      $	 116��6!   $	 151��63   $	��120��6D   6P   �� 5   
   $
��MODE��6   $ 34��6   $	 191��60     MyWpfControl.StatusButton  5   
   -   5        	  Name$	 btnKeyIn��5   $   $��KEY IN��66   $	 116��6G   $	 195��6Y   $��53��6j   
   Brushs
 5      ��	LightGray��6#   ��5      	LimeGreen��6#   5        5   
   -   5        $	 btnSkip��5   $   $
��SKIP��65   $	 183��6D   $	 195��6V   $��53��6g   
 5      ��	LightGray��6#   ��5      	LimeGreen��6#   5!      5"      5#      