   M S B A M L   `   `   `  ����B  >CtrlLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:CtrlLib.UserInterface.Controls.Data.CtrlGridView0CtrlLib.UserInterface.Controls.Data.CtrlGridView  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   CtrlGridViewMainPickColor  �� Color  CtrlGridViewPickColor  CtrlGridViewPickColorTyped   CtrlGridViewAlternatingColorC    =CtrlLib.UserInterface.Controls.Data.CtrlGridView.CtrlGridView �� 
TargetType �� 	Resources �� Property  CtrlDataGridPickColor �� Value �� 
TargetType � ColumnDefinitions n�Name � Cursor	 �� Orientation
 ��Name �� Padding �� TextAlignment ��Name ��Name ��Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value J� SnapsToDevicePixels �� Padding �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jeditors>clr-namespace:CtrlLib.UserInterface.Controls.Data.CtrlGridView  5      %[  (��       5      * SystemColors.HighlightBrushKey+)&	       &	 <     &	 ]     &	 |     '   �     7  7   7   7  7  ��6   #60646D��6Q   �� 5      $  #bdc3c7��68   �� 5      $  #bdc3c7��64   ��5	      #bdc3c7��68   �� 5      $  #D4DDDF��6;   �� 5      "   6    5   
   ���� 5      '��       " ��6   .�5      ��  � ��8   6/   �� 5       � ��$ 14(�6-   �� 5       � ��
 �   �6/   �� 5       � ��$ 0q�6,   �� 5       � ��
 ���� 60   �� 5       �@�OverridesDefaultStyle . 6:   �� 5       � ��$ Stretch=�66   �� 5       � �� 5      �� 5      " ��6*   .R�5      � #��z��6#    5   "   �� 5   &   $
��Auto �67   �� 5   &   $��* �67   .+�5   "   n� $ PART_HeaderGripper��6(   $��0��6D   $��Right=�5    1   $��2��5!   1   $��1 0 1 0q�6;   
�������$ SizeWE��5#   1   �� 5%   "   $��0 1 0 1q�6)   8�� 
������ $��1��6�   ._�5&   &   �� $	 Vertical=�61   .+�5'   *   �� $
 ContentHeader��64   #��z��6K   $ 5 5 5 0q�6l   #��z��6~   8�� $
 Left=�6�   �� 5)   *   $ filterTextBox��62   $��Normal"�6I   .��6]   ��5*   .   �� 5+   2   .R�5,   6   �� $ TextBoxShape��6=   #��z��5-   A   
������ $��1 1 0 0q�5/   A   $��25��50   A   ._�51   :   �� $ PART_ContentHost��6G   $��Center=�6a   $��0 0 3 0q�6|   52   7   53   3   .��54   @   55   +   56   '   57   #   58      59      5;      5<      5>      .�5@   
   ��  � ��$ 14(�6%   �� 5A   
    � �� 5B      �� 5C      " ��6   .�5D      ��  � ��$ 0 0 0 1q�68   �� 5E       � ��
 �����64   �� 5F       � �� 5G      �� 5H      " ��6.   .R�5I   "   �� $ border��6)   
������  5J   &     5K   *   CommonStates��. 5L   .     
Normal��6:     5M   .   Disabled��6:   5N   +     5O   *   SelectionStates��. 5P   .     
Unselected��6:     5Q   .   Selected��. 5R   2   �� .��5S   6   �� $ border��6S   $0 *(Panel.Background).(SolidColorBrush.Color)�5T   ?   .g�5U   :     $ 0��6N   8  6Z   5V   7   5W   3   5X   /     5Y   .   SelectedUnfocused��. 5Z   2   �� .��5[   6   �� $ border��6S   $0 *(Panel.Background).(SolidColorBrush.Color)�5\   ?   .g�5]   :     $ 0��6N   8  6Z   5^   7   5_   3   5`   /   5a   +   ._�5c   &   �� #��z��5d   7   # z 5e   7   5f   #   5g      5i      5j      5l      �� 5m   
    � ��$ 0q�6,   �� 5n   
    � �� 5o      �� 5p      "   6"   .R�5q      �� $ Bd��6   #��z��6)   #��z��6U   #��z��6�   $ 1q�6�    . ._�5r      �� |�.  #��z��69   .��5s      �� # z 6-   5t      5u       5v      P� 5w       � {� .  . �5x      �� $ Bd��6;    � ��
 �����6K   �� 5y      $ Bd��6<    � �� �	#FFD9D9D96L   5z      ]� 5{       5|      �� 5}   "    �@��
IsGrouping . 6B   �� 5~   "   " �@%�IsVirtualizingWhenGrouping .  6d   ./�5�      ��  � �� .  6N   5�      5�      5�      5�      5�      