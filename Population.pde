import java.util.Arrays;

class Population {
  int size;
  Snake[] snakes;
  float world_best_fitness;
  float generation_best_fitness;
  int generation_best_snake;
  int generation;
  int top;
  int[][] parents;
  boolean play;

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  //constructor
  Population(int s) {
    world_best_fitness = 0;
    play = false;

    size = s;
    top = (int)(size * TOP_POPULATION);
    snakes = new Snake[size];
    parents = new int[size-top][2];

    for (int i = 0; i < size; i++)
      snakes[i] = new Snake();
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  //top snakes are only reporoducing - chooses parents to new snake
  void selection() {
    Arrays.sort(snakes);

    int total_fitness = 0;

    for (int i = 0; i < top; i++)
      total_fitness += snakes[i].fitness;

    int p1, p2, temp;
    boolean b1 = false, b2 = false;

    for (int i = 0; i < (size - top); i++) {
      do {
        temp = 0;
        p1 = (int)random(total_fitness);
        p2 = (int)random(total_fitness);
        b1 = false;
        b2 = false;

        for (int j = 0; j < top; j++) {
          temp += snakes[j].fitness;

          if (p1 <= temp && !b1) {
            parents[i][0] = j;
            b1 = true;
          }

          if (p2 <= temp && !b2) {
            parents[i][1] = j;
            b2 = true;
          }
        }
      } while (parents[i][0] == parents[i][1]);
    }
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  //creating new snakes by crossovering their parents
  void breeding() {
    Snake[] offspring = new Snake[size];
    selection(); 
    
    for (int i = 0; i < top; i++)
      offspring[i] = new Snake(snakes[i]); 

    for (int i = top; i < size; i++) {
      offspring[i] = new Snake();

      int p1 = parents[i-top][0]; 
      int p2 = parents[i-top][1]; 

      offspring[i].d.crossover(snakes[p1].d, snakes[p2].d); 
      offspring[i].d.mutation();
    }

    for (int i = 0; i < size; i++) {
      snakes[i] = new Snake(offspring[i]);
    }

    generation ++;
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  //runs whole population; "play" decides if to play current best snake or run other snakes
  void execute() {
    if (!play) {
      for (int i = 0; i < size; i++) {
        while (snakes[i].alive())
          snakes[i].update(); 

        if (snakes[i].fitness > world_best_fitness)
          world_best_fitness = snakes[i].fitness; 

        if (snakes[i].fitness > generation_best_fitness) {
          generation_best_fitness = snakes[i].fitness; 
          generation_best_snake = i;
        }
      }

      snakes[generation_best_snake].restart(); 
      play = true;
    } else {
      snakes[generation_best_snake].update(); 
      snakes[generation_best_snake].show(); 

      text(String.format("WORLD BESTSCORE: %.0f", world_best_fitness), 5, 50); 
      text(String.format("GENERATION BESTSCORE: %.0f", generation_best_fitness), 5, 100); 
      text(String.format("GENERATION: %d", generation), 5, 150); 

      if (!snakes[generation_best_snake].alive()) {
        generation_best_fitness = 0; 
        play = false; 
        breeding();
      }
    }
  }
}
