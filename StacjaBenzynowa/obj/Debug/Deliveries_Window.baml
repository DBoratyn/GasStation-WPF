   M S B A M L   `   `   `  ����J  FStacjaBenzynowa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:StacjaBenzynowaStacjaBenzynowa  5   	   '    !StacjaBenzynowa.Deliveries_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:StacjaBenzynowa     5   	     � Title$  Dostawy��5   	   $	��230��6   $��350         ��6&    � 
ResizeMode$ CanMinimize=�5	      .��5
      �  J� Opacity$ 0.985Q�6   
�������.+�5   
   �� -   5         ��Name$ 
Wlasciciel��5      $$��Wybierz paliwo i podaj ilość��6$   $
��Left=�6K   $��	30,10,0,0q�5      $	��Top=�6    $��Copperplate Gothic Bold)�68   $
��Bold"�6]   $��16(�6o   
���   �$	��275��5       $��Italic$�6B   ��6,   Z� 6B   �� 5   
   -   5        $ Wlasciciel_Copy��5      $��Benzyna E95��6)   $
��Left=�6?   $��	55,38,0,0q�5      $	��Top=�6    $��Copperplate Gothic Light)�68   $
��Bold"�6^   $��14(�6p   
���   �$	��125��5       $��Italic$�6B   ��6,   Z� 6B   �� 5   
   -   5        $ Wlasciciel_Copy1��5      $	��LPG��6*   $
��Left=�68   $��
55,120,0,0q�5      $	��Top=�6!   $��Copperplate Gothic Light)�69   $
��Bold"�6_   $��14(�6q   
���   �$	��125��5       $��Italic$�6B   ��6,   Z� 6B   �� 5   
   -   5        $ Wlasciciel_Copy2��5      $��Olej napędowy��6*   $
��Left=�6B   $��	55,92,0,0q�5      $	��Top=�6    $��Copperplate Gothic Light)�68   $
��Bold"�6^   $��14(�6p   
���   �$	��125��5       $��Italic$�6B   ��6,   Z� 6B   �� 5   
   -   5        $ Wlasciciel_Copy3��5      $��Benzyna E98��6*   $
��Left=�6@   $��	55,65,0,0q�5      $	��Top=�6    $��Copperplate Gothic Light)�68   $
��Bold"�6^   $��14(�6p   
���   �$	��125��5       $��Italic$�6B   ��6,   Z� 6B   �� 5   
   -   5         ��Name$ be95textBox��5   8   $
��Left=�6M   $��23��6h   $��
185,38,0,0q�6t    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��50��6�   
���   �
���   �$��Copperplate Gothic Light)�6�   ��6�   Z� 6�   �� 5   
   -   5        $ be98textBox��5   8   $
��Left=�6M   $��23��6h   $��185,120,0,0q�6t   $
 Wrap=�6�   $	��Top=�6�   $��50��6�   
���   �
���   �$��Copperplate Gothic Light)�6�   ��6�   Z� 6�   �� 5   
   -   5        $ 	ontextBox��5   6   $
��Left=�6I   $��23��6d   $��
185,92,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $��50��6�   
���   �
���   �$��Copperplate Gothic Light)�6�   ��6�   Z� 6�   �� 5   
   -	   5        $ 
lpgtextBox��5   7   $
��Left=�6K   $��23��6f   $��
185,65,0,0q�6r   $
 Wrap=�6�   $	��Top=�6�   $��50��6�   
���   �
���   �$��Copperplate Gothic Light)�6�   ��6�   Z� 6�   �� 5   
   -
   5        $ Wlasciciel_Copy4��5      $��l��6*   $
��Left=�66   $��
240,39,0,0q�5      $	��Top=�6!   $��Copperplate Gothic Light)�69   $
��Bold"�6_   $��14(�6q   
���   �$��20��5        $��Italic$�6A   ��6+   Z� 6A   �� 5!   
   -   5        $ Wlasciciel_Copy5��5!      $��l��6*   $
��Left=�66   $��240,118,0,0q�5"      $	��Top=�6"   $��Copperplate Gothic Light)�6:   $
��Bold"�6`   $��14(�6r   
���   �$��20��5#       $��Italic$�6A   ��6+   Z� 6A   �� 5$   
   -   5        $ Wlasciciel_Copy6��5$      $��l��6*   $
��Left=�66   $��
240,90,0,0q�5%      $	��Top=�6!   $��Copperplate Gothic Light)�69   $
��Bold"�6_   $��14(�6q   
���   �$��20��5&       $��Italic$�6A   ��6+   Z� 6A   �� 5'   
   -   5        $ Wlasciciel_Copy7��5'      $��l��6*   $
��Left=�66   $��
240,65,0,0q�5(      $	��Top=�6!   $��Copperplate Gothic Light)�69   $
��Bold"�6_   $��14(�6q   
���   �$��20��5)       $��Italic$�6A    J� RenderTransformOrigin$ 0.5,0.24&�6T   ��6+   Z� 6T   �� 5*   
   -   5         ��Name$ back_button��5*      $��Wróć��6'   $
��Left=�66   $��
10,170,0,0q�5+      $	��Top=�6!   $��60��69   
���   �$��Copperplate Gothic Bold)�5,       $��16(�6E   $
��Bold"�6S   ��5+   D   Z� ��6Z   Z� 5,   e   �� 5-   
   -   5        $ order_button��5-      $��Zamów��6(   $
��Left=�68   $��255,170,0,0q�5.      $	��Top=�6"   $��70��6:   
���   �$��Copperplate Gothic Bold)�5/       $��16(�6E   $
��Bold"�6S   ��5.   E   Z� ��6[   Z� 5/   e   51      52      