   M S B A M L   `   `   `  ����@  <cpMgr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:cpMgrcpMgr  5          cpMgr.PageCstHistory   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:cpMgr     5      -   5          N� Title$  CST HISTORY��5	      .��5      � .+�5   
   �� $��TODAY COUNT��6   $
��Left=�6&   $��	10,16,0,0q�6A   $	��Top=�6T   �� 5   
   -   5         ��Name$ txtTodayCount��5      $
��Left=�6)   $��23��6D   $��
104,18,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $��0��6x    �� TextAlignment$ Right=�6�    �� 
IsReadOnly . $	��Top=�6�   $��77��6�   �� 5   
   $��YESTERDAY COUNT��6   $
��Left=�6*   $��
230,16,0,0q�6E   $	��Top=�6Y   �� 5   
   -   5        $ txtYesterDay��5      $
��Left=�6(   $��23��6C   $��
348,18,0,0q�6O   $
 Wrap=�6c   $��0��6w   $ Right=�6�    . $	��Top=�6�   $��77��6�   �� 5   
   $��TOTAL COUNT��6   $
��Left=�6&   $��
485,16,0,0q�6A   $	��Top=�6U   �� 5   
   -   5        $ txtTotalCount��5      $
��Left=�6)   $��23��6D   $��
576,18,0,0q�6P   $
 Wrap=�6d   $��0��6x   $ Right=�6�    . $	��Top=�6�   $��77��6�   �� 5   
   -   5         ��Name$ 	listView1��5      $��10,57,344,10q�6&   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 63   �� *brush+�� 5       � ��$ Stretch=�6C   5      	 �� View	 5      �� 5      
 �� AllowsColumnReorder
 . .P�5      �� $��NO��6%    �� Width$ 50��61    �� CellTemplate 5      �� 5      .R�5   "   ��  �� TextAlignment$ Right=�6,   ��6B   �� *no+5      5!      �� 5"      $��IN��6%   $	 150��61    �� DisplayMemberBinding 6=   �� *indata+�� 5#      $	��OUT��6%   $	 150��62    6>   �� *	outdata+�� 5$      $��ID��6%   $	 150��61    5%      �� 5&      .R�5'   "   �� $ Right=�6,   ��6B   �� *iddata+5(      5*      5+      5-      5.      5/      