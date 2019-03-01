final float SIZE = 40;
final int W = 1280; //both, the width and height, should be divided by size
final int H = 800;
final int POPULATION = 2000;
final float MUTATION_RATE = 0.01; // how often mutation occurs
final int HIDDEN_NODES = 8;
final float TOP_POPULATION = 0.2;
int speed = 40;
Population pop = new Population(POPULATION);

void settings() {
  size(W, H);
}

void setup() {
  fill(255);
  textSize(40);
  frameRate(speed);
}

void draw() {
  background(0);
  pop.execute();
}
