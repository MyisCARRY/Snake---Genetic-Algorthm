import java.util.Collections;

int score_at_start = 1;
int score_for_food = 1;
//int score_for_good_move = 3;
//int score_for_bad_move = 0;
//int score_for_collision = -100;
int moves_at_start = 200;
int moves_for_food = 100;

class Snake implements Comparable<Snake> {
  ArrayList<PVector> body;
  PVector head;
  PVector acceleration;
  PVector food;
  float[] wall_distance;
  float[] body_distance;
  float foodDistX, foodDistY;
  float dist;
  int len;
  int score;
  int steps;
  int moves_left;
  int fitness;
  char dir;
  boolean alive;
  DNA d = new DNA();

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  //constructor
  Snake() {
    head = new PVector((float)floor((W/SIZE)/2)*SIZE, (float)floor((H/SIZE)/2)*SIZE);
    body = new ArrayList<PVector>();
    len = 1;
    acceleration = new PVector(SIZE, 0);
    food = new PVector(floor(random(W/SIZE))*SIZE, floor(random(H/SIZE))*SIZE);
    wall_distance = new float[4];
    body_distance = new float[4];
    score = score_at_start;
    moves_left = moves_at_start;
    steps = 0;
    dist = PVector.dist(head, food);
    dir = 'e';
    alive = true;
    fitness = 0;
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  //copying constructor
  Snake(Snake s) {
    head = new PVector((float)floor((W/SIZE)/2)*SIZE, (float)floor((W/SIZE)/2)*SIZE);
    body = new ArrayList<PVector>();
    len = 1;
    acceleration = new PVector(SIZE, 0);
    food = new PVector(floor(random(W/SIZE))*SIZE, floor(random(H/SIZE))*SIZE);
    wall_distance = new float[4];
    body_distance = new float[4];
    score = 0;
    steps = 0;
    moves_left = moves_at_start;
    dist = PVector.dist(head, food);
    dir = 'e';
    alive = true;
    d = new DNA(s.d);
    fitness = 0;
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  // showing the snake on the screen
  void show() {
    fill(255, 0, 0);
    rect(head.x, head.y, SIZE, SIZE);

    fill(0, 255, 0);
    rect(food.x, food.y, SIZE, SIZE);

    for (PVector b : body) {
      fill(255);
      rect(b.x, b.y, SIZE, SIZE);
    }

    fill(255);
    text(String.format("score: %d", score), 10, 250);
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  // updating the snake positions 
  void update() {
    //distance between head and walls
    wall_distance[0] = head.y / SIZE;
    wall_distance[1] = (height - head.y) / SIZE;
    wall_distance[2] = (width - head.x) / SIZE;
    wall_distance[3] = head.x / SIZE;

    body_distance[0] = wall_distance[0];
    body_distance[1] = wall_distance[1];
    body_distance[2] = wall_distance[2];
    body_distance[3] = wall_distance[3];

    //distance between head and nearest body part in each direction
    //north
    for (PVector b : body)
      if (b.x == head.x && b.y < head.y) {
        body_distance[0] = (head.y - b.y) / SIZE;
        break;
      }

    //south
    for (PVector b : body) 
      if (b.x == head.x && b.y > head.y) {
        body_distance[1] = (b.y - head.y) / SIZE;
        break;
      }

    //east
    for (PVector b : body) 
      if (b.y == head.y && b.x > head.x) { //east
        body_distance[2] = (b.x - head.x) / SIZE;
        break;
      }

    //west
    for (PVector b : body)
      if (b.y == head.y && b.x < head.x) { //west
        body_distance[3] = (head.x - b.x) / SIZE;
        break;
      }

    //distance to food
    foodDistX = (food.x - head.x) / SIZE;
    foodDistY = (food.y - head.y) / SIZE;

    char temp = d.compute(wall_distance, body_distance, foodDistX, foodDistY);

    if (temp == 'w' && dir == 's')
      direction(dir);
    else if (temp == 's' && dir == 'w')
      direction(dir);
    else if (temp == 'a' && dir == 'd')
      direction(dir);
    else if (temp == 'd' && dir == 'a')
      direction(dir);
    else {
      dir = temp;
      direction(dir);
    }

    if (body.size() > 0) {
      for (int i = body.size() - 1; i > 0; i--) 
        body.get(i).set( body.get(i-1).x, body.get(i-1).y );

      body.get(0).set( head.x, head.y );
    }

    head.add(acceleration);

    //if (PVector.dist(head, food) <= dist)
    //  good_steps += score_for_good_move;
    //else
    //  moves_left--;

    moves_left--;
    steps++;

    if (moves_left <= 0 || collision()) {
      calculate_fitness();
      alive = false;
    }

    dist = PVector.dist(head, food);

    eat();
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  void eat() { // checking if snake ate food, and if he did - growing another part
    if (food.x == head.x && food.y == head.y) {
      len++;
      score += score_for_food;
      body.add(0, new PVector(head.x, head.y));
      
      moves_left += moves_for_food;
      
      if(moves_left > 500)
        moves_left = 500;

      boolean contains;
      float x;
      float y;

      do {
        x = floor(random(W/SIZE))*SIZE;
        y = floor(random(H/SIZE))*SIZE;
        contains = false;

        for (PVector b : body) {
          if (b.x == x && b.y == y)
            contains = true;
        }
      } while (contains);

      food.set(x, y);
    }
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  boolean collision() { // checks the collision: head - body part or head - walls
    boolean collision = false;

    for (PVector b : body)
      if (b.x == head.x && b.y == head.y) {
        collision = true;
      }

    if (head.x < 0 || head.x >= W || head.y < 0 || head.y >= H)
      collision = true;

    return collision;
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  void direction(char dir) {
    switch(dir) {
    case 'w':
      acceleration.set(0, -SIZE);
      break;
    case 's':
      acceleration.set(0, SIZE);
      break;
    case 'a':
      acceleration.set(-SIZE, 0);
      break;
    case 'd':
      acceleration.set(SIZE, 0);
      break;
    }
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  boolean alive() {
    return alive;
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  void restart() {
    head = new PVector((float)floor((W/SIZE)/2)*SIZE, (float)floor((H/SIZE)/2)*SIZE);
    body = new ArrayList<PVector>();
    acceleration = new PVector(SIZE, 0);
    food = new PVector(floor(random(W/SIZE))*SIZE, floor(random(H/SIZE))*SIZE);
    score = score_at_start;
    steps = 0;
    moves_left = moves_at_start;
    dir = 'd'; // direction of snake
    alive = true;
    fitness = 0;
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  @Override
    public int compareTo(Snake s) {
    return Integer.compare(s.fitness, this  .fitness);
  }

  //-------------------------------------------------------------------------------------------------------
  //-------------------------------------------------------------------------------------------------------

  void calculate_fitness() {
    if (score < 10) {
      fitness = steps;
      fitness *= pow(2, score);
    } else {
      fitness = steps;
      fitness *= pow(2,10);
      fitness *= (score - 9);
    }
  }
}
