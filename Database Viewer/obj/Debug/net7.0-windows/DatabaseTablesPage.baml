   M S B A M L   `   `   `  ����J  FDatabase Viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Database_ViewerDatabase_Viewer  5   	   (    "Database_Viewer.DatabaseTablesPage   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Database_Viewer     5   	     � Title$  DatabaseTablesPage��5   	   $	��700��6,   $
��1200��69    � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 
ResizeMode$ NoResize=�5   	   ���#1b212e � 	Resources 5         HoverButtonStyle �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value��%I  &	        �� 5   
   " ��6)   .�5      ��  � ��$	 150��6&   �� 5       � ��$ 50��6'   �� 5       � ��$ 25(�6)   �� 5       � �� �#849c646+   �� 5       � ��
 �����6+   �� 5       � ��$ 	30 20 0 0q�6'   �� 5       � ��$
 Left=�64   �� 5       � ��$ 0q�60   �� 5       � ��
 ���� 6,   �� 5       �@�Cursor$
 Hand��6'    5      P� 5      	 �@J�IsMouseOver$

 True��61   . �5      ��  � ��
 �  ��63   �� 5       � ��$
 Bold"�63   5      5       5"      .��5%      �  � RowDefinitions 5(   
   �� 5)      $��40 �6   �� 5*      .+�5.   
   � -   5        ���#2a3245$��3��5.   $    � ColumnDefinitions 5/      �� 50      �� 51      .+�53      � .+�54      �� $��DbViewer��6   
�������$��23(�56      $��SemiBold"�57      $��21,0,0,0q�6/   58      � 59      $��2��6   .+�5:      �� $��Right=�6    �� Orientation$ 
Horizontal=�5;      .+�5<      �� -   5        $��30��5<      $��30��5=      $	��—��5>      
������ 
�������$��0q�5A      $��22(�5B      $
��bold"�5C      $��0 0 13 0q�5D      5E      �� 5G      -   5        $��30��5G      $��30��5H      $	��❌��5I      
������ 
���  ��$��0q�5L      $��20(�5M      5N      5O      5P      5Q      � 5R   
   $��2��6   .+�5S      � -   5         �Name$ Instructions��5U      $��904,87,27,86q�5T      .+�5V      �� $��If you Need To Show ��6   
�������$��26(�5X      $��SemiBold"�5Y      $��	1,120,0,0q�5Z      $	��234��5[      $	��268��5\      �� 5]      $��The Table Structure��6   
�������$��26(�5_      $��SemiBold"�5`      $��
1,-320,0,0q�5a      $��45��6-   $	��236��69   �� 5c      $��Just Click On It ��6   
�������$��26(�5e      $��SemiBold"�5f      $��31,-220,0,0q�5g      $��44��6.   $	��206��6:   5h      �� 5i      $
��Auto=�6   .��5k      � -   5        $ buttonPanel��5o   !   ���#1b1d21$	��802��5l      $	��504��5m   !   $��-270 10 0 0q�5n   !   5p      5r      � 5s      -   5        $ tablesnamesinWrapPanel��5u      $��430,-13,387,595q�5t      .+�5w      �� $��Tables��6   ���#849c64$��56(�5y      $��SemiBold"�5z      $��80��6+   $	��307��67   5{      5~      �� 5   
   -   5         ��Name$
 Back��5�      $�� ��5      $
��Left=�5�      $��
-4,0,0,595q�5�      $	��149��5�      $��65��5�      
�������$��35(�5�      $��0q�5�      $��1��5�      ��5�      �� 5�       �� ImageSource$T NG:\Projects\Projects in C#\Database Viewer\Database Viewer\Images\previous.png��6    j� Stretch$ Uniform=�5�       j� 
AlignmentX$ Center=�5�       j� 
AlignmentY$ Center=�5�      ��5�      �� 5�      " ��6   .�5�      ��  � �� �#18173563   �� 5�       �@�Cursor$
 Hand��6/    5�      P� 5�      	 �@J�IsMouseOver$

 True��69   . �5�      ��  � �� �#0f0f2d6;   5�      5�      ��5�      �� 5�       �� 
TargetType" ��6"   .R�5�      �� $��90��6   $��30��5�       �� CornerRadius$ 15��5�      #��z��5�      ._�5�      �� $��Center=�6-   $��Center=�6H   5�      5�      5�      5�      5�      