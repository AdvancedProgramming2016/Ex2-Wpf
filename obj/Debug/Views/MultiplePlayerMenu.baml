   M S B A M L   `   `   `  ����C  ?MazeMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MazeMenuMazeMenu  5   	   !    MazeMenu.MultiplePlayerMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:MazeMenu     5   	     � Title$  MultiplePlayerMenu��5   	   $	��300��6$   $	��300��61   .��5	      � .+�5
   
   �� -   5         ��Name$ listOfGameBlock��5
      $
��Left=�6-   $��	34,30,0,0q�6H   $
��Wrap=�6[   $��List of games:��6o   $	��Top=�6�   �� 5   
   -   5         ��Name$ listOfGameComboBox��5      $
��Left=�6/   $��
121,30,0,0q�6J   $	��Top=�6^   $	��120��6v   �� 5   
   -   5         ��Name$ joinGameButton��5      $��	Join Game��6)   $
��Left=�6=   $��
121,68,0,0q�6X   $	��Top=�6l   $��75��6�   �� 5   
   -   5        $ mazeNameBlock��5      $
��Left=�6+   $��
34,109,0,0q�6F   $
��Wrap=�6Z   $��
Maze name:��6n   $	��Top=�6�   �� 5   
   -   5         ��Name$ mazeNameBox��5      $
��Left=�6'   $��23��6B    �� TextWrapping$
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��120��6�   $��121,108,0,0q�6�   �� 5   
   -   5        $ mazeRowsBlock��5      $
��Left=�6+   $
��Wrap=�6F   $��
Maze rows:��6Z   $	��Top=�6l   $��
34,153,0,0q�6�   �� 5   
   -   5        $ mazeRowsBox��5      $
��Left=�6'   $��23��6B   $
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��120��6�   $��121,152,0,0q�6�   �� 5   
   -   5        $ mazeColBlock��5      $
��Left=�6*   $��
34,193,0,0q�6E   $
��Wrap=�6Y   $	��Top=�6m   �� 6�   $�Maze coloms:��6�   6�   �� 5   
   -	   5        $ mazeColsBox��5      $
��Left=�6'   $��23��6B   $��121,192,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   -
   5        $ 	startGame��5      $��
Start Game��6$   $
��Left=�69   $��121,239,0,0q�6T   $	��Top=�6i   $��75��6�   5      5      