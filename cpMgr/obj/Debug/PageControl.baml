   M S B A M L   `   `   `  ����@  <cpMgr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:cpMgrcpMgr  5      G CMyWpfControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:MyWpfControl;assembly=MyWpfControlMyWpfControl 5          cpMgr.PageControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:cpMgr     5      IMyWpfControl0clr-namespace:MyWpfControl;assembly=MyWpfControl     5      -   5          N� Title$  CONTROL��5
       N� 
Background
 �����.��5      �� .+�5   
   �� 
���   �$��1q�6%   $	��377��69    �� Left$ 98��6F   
 �� Top$ 81��6W   $	��823��6g   
�������._�5      �� 
���   �$��1q�6)   $��78,58,78,111q�6=   5      �� 5   
   $ 98��6   $ 45��6"   
�������$��37��6E   $	��118��6Q   $��1q�6]   
���   �._�5   
   �� $
��DOOR��6   $��Center=�6   $��Center=�6C   $��14(�6e   5      �� 5   
   -   5         ��Name$ lblMsg1��5      $4��.MAIN OP The internal escape switch is pressed.��6!   $	 177��6Z   $	 106��6l   $��14(�6}   $
��Bold"�6�   
���  ��6�     MyWpfControl.StatusButton  5   
   -   5          Name$ 	btnStatus��5   $   $��STATUS��67   $	 322��6H   $	 184��6Z   $	��109��6k   $��43��6w      Brushs 5      ��	LightGray��6#   ��5      Cyan��6   5        5   
   -   5        $ btnClose��5   $   $��CLOSE��66   $	 479��6F   $	 184��6X   $	��233��6i   $��43��6u    5      ��	LightGray��6#   ��5      Red��6   5        5    
   -   5        $ btnDoorLock��5    $   $��	DOOR LOCK��69   $	 322��6M   $	 259��6_   $	��109��6p   $��43��6|    5"      ��	LightGray��6#   ��5#      Cyan��6   5%        5&   
   -   5        $ 
btnLockOff��5&   $   $��LOCK OFF��68   $	 479��6K   $	 259��6]   $	��109��6n   $��43��6�    5(      ��	LightGray��6#   ��5)      Cyan��6   5+        5,   
   -   5        $ 	btnLockOn��5,   $   $��LOCK ON��67   $	 603��6I   $	 259��6[   $	��109��6l   $��43��6�    5.      ��Cyan��6   ��5/      	LightGray��6#   51      �� 52   
   $#��If the door is closed but not��6   $	 177��68   $	 353��6J   $��14(�6[   $
��Bold"�6i   
���   �6{   �� 53   
   $��LOCK ON��6   $	 377��6"   $	 353��64   $��14(�6E   $
��Bold"�6S   
���  ��6e   �� 54   
   $��, the drive��6   $	 455��6&   $	 353��68   $��14(�6I   $
��Bold"�6W   
���   �6i   �� 55   
   $��POWER��6   $	 533��6    $	 353��62   $��14(�6C   $
��Bold"�6Q   
���  ��6c   �� 56   
   $��is not turned��6   $	 593��6(   $	 353��6:   $��14(�6K   $
��Bold"�6Y   
���   �6k   �� 57   
   $��ON��6   $	 695��6   $	 353��6/   $��14(�6@   $
��Bold"�6N   
���  ��6`   �� 58   
   $��
※ If not��6   $	 177��6#   $	 381��65   $��14(�6F   $
��Bold"�6T   
���   �6f   �� 59   
   $��DOOR LOCK ON��6   $	 245��6'   $	 381��69   $��14(�6J   $
��Bold"�6X   
���  ��6j   �� 5:   
   $	��the��6   $	 369��6   $	 381��60   $��14(�6A   $
��Bold"�6O   
���   �6a   �� 5;   
   $��SCREEN��6   $	 406��6!   $	 381��63   $��14(�6D   $
��Bold"�6R   
���  ��6d   �� 5<   
   $��will not switch.��6   $	 468��6+   $	 381��6=   $��14(�6N   $
��Bold"�6\   
���   �6n   5>      5?      