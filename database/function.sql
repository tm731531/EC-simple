CREATE OR REPLACE FUNCTION create_month_partitions(
    parent_table TEXT,
    start_date DATE,
    months_ahead INT
) RETURNS void AS $$
DECLARE
    m INT;
    month_start DATE;
    month_end DATE;
    partition_name TEXT;
BEGIN
    FOR m IN 0..(months_ahead - 1) LOOP
        month_start := date_trunc('month', start_date) + (m || ' months')::INTERVAL;
        month_end := month_start + INTERVAL '1 month';
        partition_name := format('%s_%s', parent_table, to_char(month_start, 'YYYY_MM'));

        -- 動態建立分區表（已存在就跳過）
        EXECUTE format(
            'CREATE TABLE IF NOT EXISTS %I PARTITION OF %I
             FOR VALUES FROM (%L) TO (%L);',
            partition_name, parent_table, month_start, month_end
        );
    END LOOP;
END;
$$ LANGUAGE plpgsql;