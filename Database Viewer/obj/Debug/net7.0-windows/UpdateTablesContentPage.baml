   M S B A M L   `   `   `  ����J  FDatabase Viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Database_ViewerDatabase_Viewer  5   	   -    'Database_Viewer.UpdateTablesContentPage   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Database_Viewer     5   	     � Title$  UpdateTablesContentPage��5   	   $	��780��61   $
��1300��5	   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   ���#0f0f2d � 	Resources 5         RoundedTextBoxStyle �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius
 ��Name��%�  &	        �� 5   
   " ��6,   .�5      ��  � ��
 �   �6+   �� 5       � ��
 �����6+   �� 5       � ��$ 1q�60   �� 5       � ��
 �   �6,   �� 5       � ��$ 5q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $	 10��5      ._�5      �� $
 PART_ContentHost��6+   5      5      5       5!      5"      .��5%      �  � ColumnDefinitions 5&   
   �� 5'      $
��279* �6   �� 5(      $
��371* �6    � RowDefinitions 5-   
   �� 5.      $��40 �6   �� 5/      .+�54   
   � -   5        ���#181735$��2��54   $   $��0,-8,0,8q�6S    55      �� 56      �� 57      .+�59      � .+�5;      �� $��DbViewr��6   
�������$��25(�5=      $��SemiBold"�5>      $��44,-4,-220,4q�6+   5?      � 5@      $��2��6   .+�5A      �� $��Right=�6    �� Orientation$ 
Horizontal=�5B      .+�5C      �� -   5        $��30��5C      $��30��5D      $	��—��5E      
������ 
�������$��0q�5H      $��22(�5I      $
��bold"�5J      $��0 0 13 0q�5K      5L      �� 5M      -   5        $��30��5M      $��30��5N      $	��❌��5O      
������ 
���  ��$��0q�5R      $��20(�5S      5T      5U      5V      5W      � 5a   
   $��2��6   .+�5c      �� $��54,107,69,-702q�6   .+�5d      &   System.Windows.Controls.DataGrid  -   5          Name$ TableContentColumns��5e      $	��628��5d         AutoGenerateColumns$
 True��5f         
IsReadOnly$
 True��5g      $��Stretch=�5h         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5i       5j      =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell��%�  '        '      '  F    �� 5k      "  6    .�5l      ��  � �� �#0f0f2d6;   �� 5m       � �� �	#FFFF09836;   �� 5n       � ��$ 16(�69   �� 5o       � ��$ Center=�6K   �� 5p       � ��$ 1q�6@   �� 5q       � ��
 �����6<   5r      �� 5s      "  6    .�5t      ��  � �� �#0f0f2d6;   �� 5u       � �� �#849c646;   �� 5v       � ��$ 20(�69   �� 5w       � ��$ SemiBold"�6;   �� 5x       � ��$ Center=�6K   �� 5y       � ��$ 1q�6@   �� 5z       � ��
 �����6<   5{      �� 5|      "  6    .�5}      ��  � �� �#0f0f2d6;   5~      5      5�      5�      5�      �� 5�   
   -   5         ��Name$
 Back��5�      $�� ��5�      $
��Left=�5�      $��-8,34,0,681q�5�      $	��149��5�      $��65��5�      
�������$��35(�5�      $��0q�5�      $��2��5�   "   ��5�      �� 5�       �� ImageSource$T NG:\Projects\Projects in C#\Database Viewer\Database Viewer\Images\previous.png��6    j� Stretch$ Uniform=�5�       j� 
AlignmentX$ Center=�5�       j� 
AlignmentY$ Center=�5�      ��5�      �� 5�      " ��6   .�5�      ��  � �� �#18173563   �� 5�       �@�Cursor$
 Hand��6/    �� Triggers 5�      P� 5�       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5�      ��  � �� �#0f0f2d6;   5�      5�      ��5�      �� 5�      " ��6"   .R�5�      �� $��90��6   $��30��5�      $	 15��5�      #��z��5�      ._�5�      �� $��Center=�6-   $��Center=�6H   5�      5�      5�      5�      5�      