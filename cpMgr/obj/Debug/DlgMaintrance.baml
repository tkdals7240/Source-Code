   M S B A M L   `   `   `  ����@  <cpMgr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:cpMgrcpMgr  5   	   G CMyWpfControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:MyWpfControl;assembly=MyWpfControlMyWpfControl 5   	       cpMgr.DlgMaintrance   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:cpMgr     5   	   IMyWpfControl0clr-namespace:MyWpfControl;assembly=MyWpfControl     5   	     � Title$  DlgMaintrance��5	   	   $	��762��6   $
��1040��6,   .��5
      �� 
���  ��.+�5   
   �� -   5         ��Name$ 
lbDataTime��5      $��yyyy/mm/dd hh:mm:ss��6$    �� Left$	 871��6B   
 �� Top$ 10��6T   $��Right=�6d   $	��Top=�6�   �� 5   
   $��/Resources/DoNotTouch.png��6   $	��225��63   $	 385��6@   $ 75��6R   $	��225��6b   �� 5   
   $��Do not operate��6   
�������$	 411��6<   $	 305��6N   $��20(�6_   $
��Bold"�6m   �� 5   
   $"��Equipment check Under repair��6   
�������$	 355��6J   $	 347��6\   $��20(�6m   $
��Bold"�6{   �� 5   
   
���   �$��1q�6%   $	��310��69   $	 195��6F   $	 401��6X   $	��691��6i   �� 5   
   -   5         ��Name$ 	listView1��5      $	��278��6&   $	 213��63   $	 417��6E   $	��549��6V   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 63   �� *brush+�� 5       � ��$ Stretch=�6C   5       �� View 5      �� 5      	 �� AllowsColumnReorder	 . .P�5      �� $
��Date��6%   
 �� Width$	
 140��63    �� DisplayMemberBinding 6?   �� *time+�� 5      $
��Trig��6%   $
 70��63    �� CellTemplate 5      �� 5      .R�5   "   ��  �� TextAlignment$ Right=�6,   ��6B   �� *no+5      5       �� 5!      $��Message��6%   $	
 355��66    6B   �� *	message+5"      5$        MyWpfControl.StatusButton  5%   
   -   5          Name$ btnLight��5%   $   $��	LIGHT OFF��66   $	 767��6J   $	 418��6\   $	��108��6m   $��26��6y   6�     5&   
   -   5        $ 	btnBuzzer��5&   $   $��Buzzer Stop��67   $	 767��6M   $	 460��6_   $	��108��6p   $��26��6|   6�     5'   
   -   5        $ btnReset��5'   $   $��Reset��66   $	 767��6F   $	 502��6X   $	��108��6i   $��26��6u   6�     5(   
   -   5        $
��Exit��5(   $   $	 767��63   $	 669��6E   $	��108��6V   $��26��6b   6n   5)      5*      