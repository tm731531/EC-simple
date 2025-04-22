-- 📦 platform
CREATE TABLE platform (
    id VARCHAR(20) PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    code VARCHAR(20) NOT NULL UNIQUE,
    created_at TIMESTAMP NOT NULL DEFAULT NOW()
);

-- 📦 channel
CREATE TABLE channel (
    id VARCHAR(20) PRIMARY KEY,
    platform_id VARCHAR(20) NOT NULL,
    name VARCHAR(50) NOT NULL,
    code VARCHAR(20) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    CONSTRAINT fk_channel_platform FOREIGN KEY (platform_id) REFERENCES platform(id)
);
CREATE UNIQUE INDEX idx_channel_code_platform ON channel (platform_id, code);

-- 📦 product
CREATE TABLE product (
    id VARCHAR(20) PRIMARY KEY,
    sku VARCHAR(30) NOT NULL UNIQUE,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    created_at TIMESTAMP NOT NULL DEFAULT NOW()
);

-- 📦 sellpack
CREATE TABLE sellpack (
    id VARCHAR(20) PRIMARY KEY,
    product_id VARCHAR(20) NOT NULL,
    code VARCHAR(30) NOT NULL UNIQUE,
    pack_name VARCHAR(50) NOT NULL,
    price NUMERIC(10,2) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    CONSTRAINT fk_sellpack_product FOREIGN KEY (product_id) REFERENCES product(id)
);

-- 📦 order（主表，用 order_date 做範圍分區）
CREATE TABLE order_main (
    id VARCHAR(20) NOT NULL,
    order_no VARCHAR(40) NOT NULL,
    channel_id VARCHAR(20) NOT NULL,
    product_id VARCHAR(20)  NULL,
    sellpack_id VARCHAR(20)  NULL,
    quantity INT NOT NULL,
    total_amount NUMERIC(12,2) NOT NULL,
    order_date DATE NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    PRIMARY KEY (id),
    CONSTRAINT fk_order_channel FOREIGN KEY (channel_id) REFERENCES channel(id),
    CONSTRAINT fk_order_sellpack FOREIGN KEY (sellpack_id) REFERENCES sellpack(id),
    CONSTRAINT fk_order_product FOREIGN KEY (product_id) REFERENCES fk_order_product(id)
) PARTITION BY RANGE (order_date);

-- 📦 global_config
CREATE TABLE global_config (
    id VARCHAR(20) PRIMARY KEY,
    value TEXT NOT NULL,              -- 設定值，可為 JSON 字串
    description TEXT,                        -- 說明文字
    updated_at TIMESTAMP NOT NULL DEFAULT NOW() -- 最後更新時間
);


-- 📦 範例分區：order_2025_q1
CREATE TABLE order_2025_q1 PARTITION OF order_main
FOR VALUES FROM ('2025-01-01') TO ('2025-04-01');

-- 📦 範例索引（可用於所有分區）
CREATE INDEX idx_order_order_no ON order_main (order_no);
CREATE INDEX idx_order_order_date ON order_main (order_date);
CREATE INDEX idx_order_channel_id ON order_main (channel_id);
CREATE INDEX idx_order_sellpack_id ON order_main (sellpack_id);
